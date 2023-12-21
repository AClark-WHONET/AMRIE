using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Engine
{
	public class IO_Library
	{
		#region Constants

		private class OutputAntibioticColumns
		{
			public const string AntibioticCode = "ANTIBIOTIC_CODE";
			public const string AntibioticMeasurement = "ANTIBIOTIC_MEASUREMENT";
			public const string AntibioticInterpretation = "ANTIBIOTIC_INTERPRETATION";

			public static readonly string[] VerticalAntibioticFields = {
				AntibioticCode,
				AntibioticMeasurement,
				AntibioticInterpretation
			};
		}

		#endregion

		#region Public

		/// <summary>
		/// Process an entire data file, generating an output file with the interpretations.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		public static void InterpretDataFile(object s, DoWorkEventArgs e)
		{
			FileInterpretationParameters arguments = (FileInterpretationParameters)e.Argument;
			if (arguments.Worker != null)
				arguments.Worker.ReportProgress(0);

			InterpretationConfiguration interpretationConfig =
				InterpretationConfiguration.ReadConfiguration(arguments.ConfigFile);

			int headerLineNumber = 0;
			List<string> inputColumnNames = new List<string>();
			List<Dictionary<string, string>> rowValueSets = new List<Dictionary<string, string>>();
			LoadInputFile(e, arguments, ref headerLineNumber, ref inputColumnNames, rowValueSets);

			Tuple<Dictionary<string, string>, Dictionary<string, string>>[] interpretationResults =
				InterpretIsolates(e, arguments, interpretationConfig, inputColumnNames, rowValueSets);

			GenerateOutputFile(e, arguments, interpretationConfig, inputColumnNames, interpretationResults);
		}

		/// <summary>
		/// Get the headers for the a resource file header line provided.
		/// </summary>
		/// <param name="headerLine"></param>
		/// <returns></returns>
		public static Dictionary<string, int> GetHeaders(string headerLine)
		{
			Dictionary<string, int> headerMap = new Dictionary<string, int>();
			string[] headerValues = headerLine.Split(Constants.Delimiters.TabChar);
			for (int i = 0; i < headerValues.Length; i++)
			{
				headerMap.Add(headerValues[i], i);
			}

			return headerMap;
		}

		#endregion

		#region Private

		/// <summary>
		/// Convert the input file into a list of dictionaries for each row to facilitate processing.
		/// </summary>
		/// <param name="e"></param>
		/// <param name="arguments"></param>
		/// <param name="headerLineNumber"></param>
		/// <param name="inputColumnNames"></param>
		/// <param name="rowValueSets"></param>
		private static void LoadInputFile(
			DoWorkEventArgs e,
			FileInterpretationParameters arguments,
			ref int headerLineNumber,
			ref List<string> inputColumnNames,
			List<Dictionary<string, string>> rowValueSets)
		{
			Dictionary<int, string> headers = new Dictionary<int, string>();

			using (StreamReader inputReader = new StreamReader(arguments.InputFile))
			{
				while (!inputReader.EndOfStream)
				{
					if (arguments.Worker != null && arguments.Worker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					string thisLine = inputReader.ReadLine();

					if (!string.IsNullOrWhiteSpace(thisLine))
					{
						// Process header row.
						string[] headerValues = thisLine.Split(arguments.Delimiter);

						for (int x = 0; x < headerValues.Length; x++)
							headers.Add(x, headerValues[x]);

						break;
					}

					headerLineNumber++;
				}

				inputColumnNames = headers.Values.ToList();

				// Transfer the lines into value dictionaries.
				// Don't add empty fields to the row's set.
				// Don't add anything for a blank line.
				while (!inputReader.EndOfStream)
				{
					if (arguments.Worker != null && arguments.Worker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					string thisLine = inputReader.ReadLine();

					if (!string.IsNullOrWhiteSpace(thisLine))
					{
						string[] values = thisLine.Split(arguments.Delimiter);

						// Transfer the value array into a row dictionary.
						Dictionary<string, string> rowValues = new Dictionary<string, string>();

						for (int x = 0; x < values.Length; x++)
							if (!string.IsNullOrWhiteSpace(values[x]))
								rowValues.Add(headers[x], values[x]);

						rowValueSets.Add(rowValues);
					}
				}
			}
		}

		/// <summary>
		/// Parallel interpretation for all rows in the provided data set.
		/// </summary>
		/// <param name="e"></param>
		/// <param name="arguments"></param>
		/// <param name="interpretationConfig"></param>
		/// <param name="inputColumnNames"></param>
		/// <param name="rowValueSets"></param>
		/// <returns></returns>
		private static Tuple<Dictionary<string, string>, Dictionary<string, string>>[] InterpretIsolates(
			DoWorkEventArgs e,
			FileInterpretationParameters arguments,
			InterpretationConfiguration interpretationConfig,
			List<string> inputColumnNames,
			List<Dictionary<string, string>> rowValueSets)
		{
			int remainingLines = rowValueSets.Count;
			int blockSize = Math.Max(1, remainingLines / (Environment.ProcessorCount * 4));
			int totalBlocks = (remainingLines / blockSize) + (remainingLines % blockSize == 0 ? 0 : 1);
			Tuple<Dictionary<string, string>, Dictionary<string, string>>[] interpretationResults =
				new Tuple<Dictionary<string, string>, Dictionary<string, string>>[remainingLines];

			object countSyncObject = new object();
			int rowCount = 0;
			int previousProgressReport = 0;

			Parallel.For(0, totalBlocks, (blockNumber, state) =>
			{
				if (arguments.Worker != null && arguments.Worker.CancellationPending)
				{
					e.Cancel = true;
					state.Break();
				}

				int blockRowStart = (blockSize * blockNumber);
				int blockRowCount = Math.Min(blockSize, rowValueSets.Count - blockRowStart);

				for (int lineNumber = blockRowStart; lineNumber < blockRowStart + blockRowCount; lineNumber++)
				{
					Dictionary<string, string> results =
					new IsolateInterpretation(rowValueSets[lineNumber],
					inputColumnNames,
					interpretationConfig.EnabledExpertInterpretationRules,
					interpretationConfig.UserDefinedBreakpoints,
					guidelineYear: arguments.GuidelineYear == -1 ? Convert.ToInt32(interpretationConfig.GuidelineYear) : arguments.GuidelineYear,
					prioritizedBreakpointTypes: interpretationConfig.PrioritizedBreakpointTypes,
					prioritizedSitesOfInfection: interpretationConfig.PrioritizedSitesOfInfection).
					GetAllInterpretations();

					// Put each original value and result set into the corresponding array position.
					// No 2 threads will have the same line number, so there is no need for a lock while saving to the results array.
					interpretationResults[lineNumber] = new Tuple<Dictionary<string, string>, Dictionary<string, string>>(rowValueSets[lineNumber], results);

					lock (countSyncObject)
					{
						rowCount++;

						int currentProgress = rowCount * 100 / remainingLines;
						if (currentProgress > previousProgressReport)
						{
							// Only report whole percentage changes.
							previousProgressReport = currentProgress;
							if (arguments.Worker != null)
								arguments.Worker.ReportProgress(currentProgress);
						}
					}
				}
			});

			return interpretationResults;
		}

		/// <summary>
		/// Saves the output in the format specified by the interpretation configuration.
		/// </summary>
		/// <param name="arguments"></param>
		/// <param name="interpretationConfig"></param>
		/// <param name="interpretationResults"></param>
		private static void GenerateOutputFile(DoWorkEventArgs e,
			FileInterpretationParameters arguments,
			InterpretationConfiguration interpretationConfig,
			List<string> inputColumnNames,
			Tuple<Dictionary<string, string>, Dictionary<string, string>>[] interpretationResults)
		{
			const string InterpSuffix = "_INTERP";

			IEnumerable<string> interpretationHeaders =
				interpretationResults.SelectMany(v => v.Item2.Keys).Distinct();

			List<string> outputHeaders = inputColumnNames.ToList();
			List<string> antibioticFields = null;

			if (interpretationConfig.HorizontalAntibioticResults)
			{
				// The order should be the same as the input files with the addition of the interpretation columns following each antibiotic.
				foreach (string interpHeader in interpretationHeaders)
					for (int x = 0; x < outputHeaders.Count; x++)
						if (outputHeaders[x] == interpHeader)
						{
							// Insert the interpretation column immediately following the associated measurement column.
							outputHeaders.Insert(x + 1, interpHeader + InterpSuffix);
							break;
						}
			}
			else
			{
				antibioticFields = outputHeaders.Where(h => IsolateInterpretation.ValidAntibioticFieldNameRegex.IsMatch(h)).ToList();

				// The antibiotics are transposed vertically. Remove the horizontal columns, and append the 3 vertical columns.
				outputHeaders = outputHeaders.Except(antibioticFields).Concat(OutputAntibioticColumns.VerticalAntibioticFields).ToList();
			}

			using (StreamWriter writer = new StreamWriter(arguments.OutputFile))
			{
				writer.WriteLine(string.Join(Constants.Delimiters.TabChar.ToString(), outputHeaders));

				foreach (Tuple<Dictionary<string, string>, Dictionary<string, string>> row in interpretationResults)
				{
					if (arguments.Worker != null && arguments.Worker.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					if (interpretationConfig.HorizontalAntibioticResults)
					{
						List<string> thisRow = new List<string>();

						foreach (string h in outputHeaders)
						{
							if (row.Item1.ContainsKey(h))
								thisRow.Add(row.Item1[h]);

							else if (h.EndsWith(InterpSuffix))
							{
								string drugCode = h.Substring(0, h.Length - InterpSuffix.Length);

								if (row.Item2.ContainsKey(drugCode))
								{
									string thisInterp = row.Item2[drugCode];
									if (!interpretationConfig.IncludeInterpretationComments)
										thisInterp = IsolateInterpretation.RemoveComments(thisInterp);

									thisRow.Add(thisInterp);
								}
								else
									thisRow.Add(string.Empty);
							}

							else thisRow.Add(string.Empty);
						}

						writer.WriteLine(string.Join(Constants.Delimiters.TabChar.ToString(), thisRow));
					}
					else
					{
						List<string> repeatedValueList = new List<string>();

						// Repeat all but the final 3 columns, which are the variable antibiotics.
						foreach (string h in outputHeaders.Take(outputHeaders.Count - 3))
						{
							if (row.Item1.ContainsKey(h))
								repeatedValueList.Add(row.Item1[h]);

							else
								repeatedValueList.Add(string.Empty);
						}

						string repeatedOutputString = string.Join(Constants.Delimiters.TabChar.ToString(), repeatedValueList);

						if (!antibioticFields.Any(a => row.Item1.ContainsKey(a)))
						{
							// This row didn't have any measurements.
							// We will still write 1 row to the output with blanks for the final three fields.
							writer.WriteLine(string.Join(Constants.Delimiters.TabChar.ToString(), repeatedOutputString, string.Empty, string.Empty, string.Empty));
						}
						else
						{
							// We need to write one row per antibiotic measurement,
							// whether it has an associated interpretation or not.
							foreach (string antibiotic in antibioticFields)
							{
								if (row.Item1.ContainsKey(antibiotic))
								{
									List<string> antibioticRowValues = new List<string>() { antibiotic, row.Item1[antibiotic] };

									if (row.Item2.ContainsKey(antibiotic))
									{
										string thisInterp = row.Item2[antibiotic];
										if (!interpretationConfig.IncludeInterpretationComments)
											thisInterp = IsolateInterpretation.RemoveComments(thisInterp);

										antibioticRowValues.Add(thisInterp);
									}
									else
										antibioticRowValues.Add(string.Empty);

									string outputLine = string.Join(Constants.Delimiters.TabChar.ToString(),
										repeatedOutputString,
										string.Join(Constants.Delimiters.TabChar.ToString(), antibioticRowValues));

									writer.WriteLine(outputLine);
								}
							}
						}
					}
				}
			}
		}

		#endregion

	}
}
