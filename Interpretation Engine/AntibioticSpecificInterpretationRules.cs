﻿using System.Collections.Generic;
using System.Linq;

namespace AMR_Engine
{
	public class AntibioticSpecificInterpretationRules
	{
		#region Init

		/// <summary>
		/// Populates the intrinsic resistance rules and breakpoints associated with the drug/bug combination.
		/// Use the lookup tables to collect this information so that we only need to make the determinations once.
		/// </summary>
		/// <param name="whonetOrganismCode"></param>
		/// <param name="whonetAntimicrobialFullCode"></param>
		/// <param name="antimicrobialResult_"></param>
		/// <param name="userDefinedBreakpoints"></param>
		/// <param name="guidelineYear"></param>
		/// <param name="roundHalfDilutions"></param>
		/// <param name="prioritizedBreakpointTypes"></param>
		/// <param name="prioritizedSitesOfInfection"></param>
		public AntibioticSpecificInterpretationRules(
			string whonetOrganismCode,
			string whonetAntimicrobialFullCode,
			string antimicrobialResult_,
			List<Breakpoint> userDefinedBreakpoints,
			int guidelineYear = -1,
			bool roundHalfDilutions = true,
			List<string> prioritizedBreakpointTypes = null,
			List<string> prioritizedSitesOfInfection = null)
		{
			RoundHalfDilutions = roundHalfDilutions;

			AntibioticComponents thisAntibiotic = new AntibioticComponents(whonetAntimicrobialFullCode);
			AntimicrobialTestMethod = thisAntibiotic.TestMethod;

			List<int> prioritizedGuidelineYears = null;
			if (guidelineYear > 0)
				prioritizedGuidelineYears = new List<int> { guidelineYear };

			AntimicrobialResult = antimicrobialResult_;

			InterpretationLibrary.ParseResult(AntimicrobialTestMethod, AntimicrobialResult, ref NumericResult, ref ResultModifier);

			lock (IntrinsicResistanceRuleLookupLock)
			{
				if (IntrinsicResistanceRuleLookup.ContainsKey(whonetOrganismCode)
				&& IntrinsicResistanceRuleLookup[whonetOrganismCode].ContainsKey(thisAntibiotic.Guideline)
				&& IntrinsicResistanceRuleLookup[whonetOrganismCode][thisAntibiotic.Guideline].ContainsKey(thisAntibiotic.Code))
					// We have seen this combination previously, so there no need for us to determine the applicable intrinsic resistance rules again.
					MostApplicableIntrinsicResistanceRule = IntrinsicResistanceRuleLookup[whonetOrganismCode][thisAntibiotic.Guideline][thisAntibiotic.Code];
				else
				{
					// We haven't seen this combination before, so we need to evaluate it.
					MostApplicableIntrinsicResistanceRule =
						ExpectedResistancePhenotypeRule.GetApplicableExpectedResistanceRules(
							whonetOrganismCode,
							new List<string>() { thisAntibiotic.Guideline },
							new List<string> { thisAntibiotic.Code }).FirstOrDefault();

					if (IntrinsicResistanceRuleLookup.ContainsKey(whonetOrganismCode))
					{
						if (IntrinsicResistanceRuleLookup[whonetOrganismCode].ContainsKey(thisAntibiotic.Guideline))
						{
							// Only missing the antibiotic part.
							IntrinsicResistanceRuleLookup[whonetOrganismCode][thisAntibiotic.Guideline].Add(thisAntibiotic.Code, MostApplicableIntrinsicResistanceRule);
						}
						else
						{
							Dictionary<string, ExpectedResistancePhenotypeRule> abxSet = new Dictionary<string, ExpectedResistancePhenotypeRule>();
							abxSet.Add(thisAntibiotic.Code, MostApplicableIntrinsicResistanceRule);

							IntrinsicResistanceRuleLookup[whonetOrganismCode].Add(thisAntibiotic.Guideline, abxSet);
						}
					}
					else
					{
						// The organism code missing, which means we need the whole structure.
						Dictionary<string, ExpectedResistancePhenotypeRule> abxSet = new Dictionary<string, ExpectedResistancePhenotypeRule>();
						abxSet.Add(thisAntibiotic.Code, MostApplicableIntrinsicResistanceRule);

						Dictionary<string, Dictionary<string, ExpectedResistancePhenotypeRule>> guidelineSet = new Dictionary<string, Dictionary<string, ExpectedResistancePhenotypeRule>>();
						guidelineSet.Add(thisAntibiotic.Guideline, abxSet);

						IntrinsicResistanceRuleLookup.Add(whonetOrganismCode, guidelineSet);
					}
				}
			}

			if (NumericResult > 0M)
			{
				lock (BreakpointLookupLock)
				{
					if (BreakpointLookup.ContainsKey(whonetOrganismCode)
					&& BreakpointLookup[whonetOrganismCode].ContainsKey(thisAntibiotic.Guideline)
					&& BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline].ContainsKey(guidelineYear)
					&& BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline][guidelineYear].ContainsKey(whonetAntimicrobialFullCode))
						// We have seen this combination previously, so there no need for us to determine the applicable breakpoints again.
						MostApplicableBreakpoint = BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline][guidelineYear][whonetAntimicrobialFullCode];
					else
					{

						// We haven't seen this combination before, so we need to evaluate it.
						List<Breakpoint> applicableBPs =
							Breakpoint.GetApplicableBreakpoints(
								whonetOrganismCode,
								userDefinedBreakpoints,
								prioritizedGuidelines: new List<string>() { thisAntibiotic.Guideline },
								prioritizedGuidelineYears: prioritizedGuidelineYears,
								prioritizedBreakpointTypes: prioritizedBreakpointTypes,
								prioritizedSitesOfInfection: prioritizedSitesOfInfection,
								prioritizedWhonetAbxFullDrugCodes: new List<string>() { whonetAntimicrobialFullCode },
								returnFirstBreakpointOnly: true);

						if (applicableBPs.Count > 0)
							MostApplicableBreakpoint = applicableBPs[0];
						else
							MostApplicableBreakpoint = null;

						// Create the missing levels in our lookup for next time, and store this breakpoint set.
						if (BreakpointLookup.ContainsKey(whonetOrganismCode))
						{
							if (BreakpointLookup[whonetOrganismCode].ContainsKey(thisAntibiotic.Guideline))
							{
								if (BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline].ContainsKey(guidelineYear))
								{
									// Only the antibiotic info missing.
									BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline][guidelineYear].Add(whonetAntimicrobialFullCode, MostApplicableBreakpoint);
								}
								else
								{
									Dictionary<string, Breakpoint> abxSet = new Dictionary<string, Breakpoint>();
									abxSet.Add(whonetAntimicrobialFullCode, MostApplicableBreakpoint);

									BreakpointLookup[whonetOrganismCode][thisAntibiotic.Guideline].Add(guidelineYear, abxSet);
								}
							}
							else
							{
								// Create everything below the organism.
								Dictionary<string, Breakpoint> abxSet = new Dictionary<string, Breakpoint>();
								abxSet.Add(whonetAntimicrobialFullCode, MostApplicableBreakpoint);

								Dictionary<int, Dictionary<string, Breakpoint>> yearSet = new Dictionary<int, Dictionary<string, Breakpoint>>();
								yearSet.Add(guidelineYear, abxSet);

								BreakpointLookup[whonetOrganismCode].Add(thisAntibiotic.Guideline, yearSet);
							}
						}
						else
						{
							// The organism key missing, which means we have to create the whole structure.
							Dictionary<string, Breakpoint> abxSet = new Dictionary<string, Breakpoint>();
							abxSet.Add(whonetAntimicrobialFullCode, MostApplicableBreakpoint);

							Dictionary<int, Dictionary<string, Breakpoint>> yearSet = new Dictionary<int, Dictionary<string, Breakpoint>>();
							yearSet.Add(guidelineYear, abxSet);

							Dictionary<string, Dictionary<int, Dictionary<string, Breakpoint>>> guidelineSet = new Dictionary<string, Dictionary<int, Dictionary<string, Breakpoint>>>();
							guidelineSet.Add(thisAntibiotic.Guideline, yearSet);

							BreakpointLookup.Add(whonetOrganismCode, guidelineSet);
						}
					}
				}
			}
		}

		#endregion

		#region Properties

		private readonly string AntimicrobialTestMethod;

		private readonly string AntimicrobialResult;

		private readonly string ResultModifier;

		private readonly decimal NumericResult;

		private readonly bool RoundHalfDilutions;

		private readonly ExpectedResistancePhenotypeRule MostApplicableIntrinsicResistanceRule;

		private static readonly Dictionary<string, Dictionary<string, Dictionary<string, ExpectedResistancePhenotypeRule>>> IntrinsicResistanceRuleLookup = new Dictionary<string, Dictionary<string, Dictionary<string, ExpectedResistancePhenotypeRule>>>();

		private static readonly object IntrinsicResistanceRuleLookupLock = new object();

		private readonly Breakpoint MostApplicableBreakpoint;

		private static readonly Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, Breakpoint>>>> BreakpointLookup = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, Breakpoint>>>>();

		private static readonly object BreakpointLookupLock = new object();

		#endregion

		#region Public

		public static void ClearBreakpoints()
		{
			lock (BreakpointLookupLock)
			{
				BreakpointLookup.Clear();
			}
		}

		/// <summary>
		/// Apply any matching intrinsic resistance rules and breakpoints for this result.
		/// </summary>
		/// <returns></returns>
		public string GetInterpretation()
		{
			string intrinsicResistanceInterp = ApplyIntrinsicResistanceRules();

			if (intrinsicResistanceInterp == Constants.InterpretationCodes.Uninterpretable)
				// The drug/bug pair not intrinsically resistant. Apply the breakpoints.
				return ApplyBreakpoints();
			else
				return intrinsicResistanceInterp;
		}

		#endregion

		#region Private

		/// <summary>
		/// If this drug/bug matches an intrinsic resistance rule, then we don't need to evaluate breakpoints.
		/// </summary>
		/// <returns></returns>
		private string ApplyIntrinsicResistanceRules()
		{
			if (MostApplicableIntrinsicResistanceRule != null)
				// This isolate intrinsically resistant. We don't need to apply the breakpoints.
				return Constants.InterpretationCodes.Resistant + Constants.InterpretationCodes.Asterisk;

			else
				return Constants.InterpretationCodes.Uninterpretable;
		}

		/// <summary>
		/// Evaluate the numeric measurement against the most-applicable breakpoint as determined by the users configuration and breakpoint hierarchy.
		/// </summary>
		/// <returns></returns>
		private string ApplyBreakpoints()
		{
			if (NumericResult > 0M)
			{
				if (MostApplicableBreakpoint != null)
				{
					if (MostApplicableBreakpoint.BREAKPOINT_TYPE == Breakpoint.BreakpointTypes.ECOFF)
					{
						// Use the ECOFF values instead of the R, I, S columns.
						switch (AntimicrobialTestMethod)
						{
							case Antibiotic.TestMethods.Disk:
								if (NumericResult >= MostApplicableBreakpoint.ECV_ECOFF)
									return Constants.InterpretationCodes.WildType;
								else
									return Constants.InterpretationCodes.NonWildType;

							case Antibiotic.TestMethods.MIC:
								// ETest also uses the MIC breakpoints.
								decimal tempNumericResult;
								if (RoundHalfDilutions)
									tempNumericResult = InterpretationLibrary.Round_ETestHalfDilutionsUp(NumericResult);
								else
									tempNumericResult = NumericResult;

								if (string.IsNullOrWhiteSpace(ResultModifier))
								{
									// No > or < symbol involved.
									if (tempNumericResult <= MostApplicableBreakpoint.ECV_ECOFF)
										return Constants.InterpretationCodes.WildType;

									else
										return Constants.InterpretationCodes.NonWildType;
								}
								else
								{
									// Must take the > or < into account.
									if (ResultModifier.StartsWith(Constants.MeasurementModifiers.GreaterThan))
									{
										if (tempNumericResult > MostApplicableBreakpoint.ECV_ECOFF)
											// Must include the question mark because of the > symbol.
											return Constants.InterpretationCodes.NonWildType;
										else
											return Constants.InterpretationCodes.NonWildType + Constants.InterpretationCodes.QuestionMark;
									}
									else
									{
										// Modifier begins with less than symbol.
										if (tempNumericResult <= MostApplicableBreakpoint.ECV_ECOFF)
											return Constants.InterpretationCodes.WildType;
										else
											// Must include the question mark because of the < symbol.
											return Constants.InterpretationCodes.WildType + Constants.InterpretationCodes.QuestionMark;
									}
								}
						}
					}
					else
					{
						// Normal human or animal breakpoint.
						switch (AntimicrobialTestMethod)
						{
							case Antibiotic.TestMethods.Disk:
								if (MostApplicableBreakpoint.S > 0M)
								{
									if (NumericResult <= MostApplicableBreakpoint.R)
										return Constants.InterpretationCodes.Resistant;

									else if (NumericResult >= MostApplicableBreakpoint.S)
										return Constants.InterpretationCodes.Susceptible;

									else if (MostApplicableBreakpoint.R > 0M)
										return Constants.InterpretationCodes.Intermediate;

									else
										return Constants.InterpretationCodes.NonSusceptible;
								}
								break;

							case Antibiotic.TestMethods.MIC:
								// ETest also uses the MIC breakpoints.
								if (MostApplicableBreakpoint.S > 0M)
								{
									decimal tempNumericResult;
									if (RoundHalfDilutions)
										tempNumericResult = InterpretationLibrary.Round_ETestHalfDilutionsUp(NumericResult);
									else
										tempNumericResult = NumericResult;

									if (string.IsNullOrWhiteSpace(ResultModifier) || ResultModifier == Constants.MeasurementModifiers.EqualsSign)
									{
										// No > or < symbol involved.
										if (tempNumericResult <= MostApplicableBreakpoint.S)
											return Constants.InterpretationCodes.Susceptible;

										else if (tempNumericResult >= MostApplicableBreakpoint.R)
										{
											if (MostApplicableBreakpoint.R > 0M)
												return Constants.InterpretationCodes.Resistant;
											else
												return Constants.InterpretationCodes.NonSusceptible;
										}
										else
											return Constants.InterpretationCodes.Intermediate;
									}
									else
									{
										// Must take the > or < into account.
										if (ResultModifier.StartsWith(Constants.MeasurementModifiers.GreaterThan))
										{
											tempNumericResult *= 2M;
											if (tempNumericResult >= MostApplicableBreakpoint.R)
											{
												if (MostApplicableBreakpoint.R > 0M)
													return Constants.InterpretationCodes.Resistant;
												else
												{
													// No "R" breakpoint.
													if (tempNumericResult > MostApplicableBreakpoint.S)
														return Constants.InterpretationCodes.NonSusceptible;
												}
											}
											else
											{
												if (tempNumericResult > MostApplicableBreakpoint.S)
													return Constants.InterpretationCodes.NonSusceptible;

												else
													// Must include the question mark because of the > symbol.
													return Constants.InterpretationCodes.Resistant + Constants.InterpretationCodes.QuestionMark;
											}
										}
										else
										{
											// Modifier begins with less than symbol.
											if (tempNumericResult <= MostApplicableBreakpoint.S)
												return Constants.InterpretationCodes.Susceptible;

											else
												// Must include the question mark because of the < symbol.
												return Constants.InterpretationCodes.Susceptible + Constants.InterpretationCodes.QuestionMark;
										}
									}
								}
								break;
						}
					}
				}
			}

			return Constants.InterpretationCodes.Uninterpretable;
		}

		#endregion

	}
}
