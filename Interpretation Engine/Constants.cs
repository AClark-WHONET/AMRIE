using System.IO;

namespace AMR_Engine
{
	public class Constants
	{
		// This should be set to the current year when annual
		// breakpoint changes are made to the Breakpoints.txt file.
		// The minor change number below should be reset to 0 each year.
		public static readonly int BreakpointTableRevisionYear = 2024;

		// This should increase whenever an issue is resolved
		// within a year to indicate that the table itself has changed.
		// For example, if there is a document correction or error on our part.
		public static readonly int BreakpointTableRevisionMinorChangeNumber = 1;

		// We use this to locate resources.
		public static string SystemRootPath = 
			Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + System.IO.Path.DirectorySeparatorChar;

		public static readonly char Quote = '"';

		public static readonly string TwoQuotes = "\"\"";

		public class Disk
		{
			public static readonly decimal MinimumDiskMeasurement = 6M;
			public static readonly decimal MaximumDiskMeasurement = 80M;
		}

		public class MIC
		{
			public static readonly decimal MinimumMIC_Measurement = 0.0001M;
			public static readonly decimal MaximumMIC_Measurement = 2048;
		}
		
		public class MeasurementModifiers
		{
			public static readonly string LessThan = "<";
			public static readonly string GreaterThan = ">";
			public static readonly string EqualsSign = "=";
			public class Invalid
			{
				public static readonly string LessThanOrEqualTo = "≤";
				public static readonly string GreaterThanOrEqualTo = "≥";
			}
		}		

		public class Delimiters
		{
			public static readonly string TabPlaceholder = "TAB";
			public static readonly char TabChar = '\t';
			public static readonly char CommaChar = ',';
			public static readonly char Underscore = '_';
			public static readonly char Space = ' ';
			public static readonly char EqualsSign = '=';
		}		

		public class CommandLineModes
		{
			public static readonly string File = "FILE";
			public static readonly string SingleInterpretation = "SINGLE_INTERPRETATION";
		}

		public class KeyFields
		{
			public static readonly string ORGANISM = "ORGANISM";
		}

		public class InterpretationCodes
		{
			public static readonly string Uninterpretable = string.Empty;
			public static readonly string Susceptible = "S";
			public static readonly string SusceptibleDoseDependent = "SDD";
			public static readonly string NonSusceptible = "NS";
			public static readonly string Intermediate = "I";
			public static readonly string Resistant = "R";
			public static readonly string Asterisk = "*";
			public static readonly string ExclamationPoint = "!";
			public static readonly string QuestionMark = "?";
			public static readonly string WildType = "WT";
			public static readonly string NonWildType = "NWT";
			public static readonly string InRange = "IN";
			public static readonly string OutOfRange = "OUT";
		}

		public class TestResultCodes
		{
			public static readonly string Positive = "+";
			public static readonly string Negative = "-";
		}
		
		public class OrganismGroups
		{
			public static readonly string GramPositiveAnaerobes = "AN" + TestResultCodes.Positive;
			public static readonly string GramNegativeAnaerobes = "AN" + TestResultCodes.Negative;
			public static readonly string Anaerobes = "ANA";
			public static readonly string AnaerobePlusSubkingdomCode = nameof(Organism.ANAEROBE) + "+" + nameof(Organism.SUBKINGDOM_CODE);
		}

		public class SitesOfInfection
		{
			public const string Blank = "(Blank)";
		}
	}
}
