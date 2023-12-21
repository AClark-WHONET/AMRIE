namespace Interpretation_CLI
{
	public class SingleInterpretation
	{
		public SingleInterpretation(string organismCode_, string antibioticCode_,
			string measurement_, string interpretation_)
		{
			OrganismCode = organismCode_;
			AntibioticCode = antibioticCode_;
			Measurement = measurement_;
			Interpretation = interpretation_;
		}

		public string OrganismCode { get; private set; }

		public string AntibioticCode { get; private set; }

		public string Measurement { get; private set; }

		public string Interpretation { get; private set; }
	}
}
