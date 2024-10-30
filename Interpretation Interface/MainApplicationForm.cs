using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AMR_Engine;

namespace AMR_InterpretationInterface
{
	public partial class MainApplicationForm : Form
	{
		#region Init

		public MainApplicationForm()
		{
			InitializeComponent();
		}

		private void MainApplicationForm_Load(object sender, EventArgs e)
		{
			GuidelineYearUpDown.Value = Constants.BreakpointTableRevisionYear;

			// Recode the empty string as "(Blank)" here for display purposes.
			// (Blank) will be processed as the empty string when we determine the applicable breakpoints.
			SitesOfInfectionCheckedListBox.Items.AddRange(
				Breakpoint.SiteOfInfection.DefaultOrder().
				Select(soi =>
				{
					if (string.IsNullOrEmpty(soi))
						return Constants.SitesOfInfection.Blank;
					else
						return soi;
				}).ToArray());

			SelectedGuidelinesCheckedListBox.SetItemChecked(0, true);
			FieldDelimiterComboBox.SelectedIndex = 0;

			// Add the full list of organisms.
			List<Tuple<string, string>> Organisms = 
				new List<Tuple<string, string>>([DefaultSelection]);

			Organisms.AddRange(
				Organism.AllOrganisms.OrderBy(o => o.ORGANISM).
				Select(o => new Tuple<string, string>(string.Format("{0} - ({1})", o.ORGANISM, o.WHONET_ORG_CODE), o.WHONET_ORG_CODE)).
				Distinct());

			OrganismComboBox.Tag = Organisms;
			OrganismComboBox.DisplayMember = nameof(DefaultSelection.Item1);
			OrganismComboBox.ValueMember = nameof(DefaultSelection.Item2);
			OrganismComboBox.DataSource = Organisms;


			// Add the full list of antibiotics.
			List<Tuple<string, string>> Antibiotics = 
				new List<Tuple<string, string>>([DefaultSelection]);

			Antibiotics.AddRange(
				Antibiotic.AllAntibiotics.OrderBy(a => a.ANTIBIOTIC).
				Select(a => new Tuple<string, string>(string.Format("{0} - ({1})", a.ANTIBIOTIC, a.WHONET_ABX_CODE), a.WHONET_ABX_CODE)).
				Distinct());

			AntibioticComboBox.Tag = Antibiotics;
			AntibioticComboBox.DisplayMember = nameof(DefaultSelection.Item1);
			AntibioticComboBox.ValueMember = nameof(DefaultSelection.Item2);
			AntibioticComboBox.DataSource = Antibiotics;
		}

		#endregion

		#region Private

		private BackgroundWorker Worker;

		private Tuple<string, string> DefaultSelection =
			new("[Select a value]", string.Empty);

		#endregion

		#region Events

		private void InterpretFileButton_Click(object sender, EventArgs e)
		{
			ToggleUI(false);

			try
			{
				string inputFile = InputFileTextBox.Text.Trim();
				if (!Path.IsPathFullyQualified(inputFile))
					inputFile = Path.GetFullPath(Constants.SystemRootPath + inputFile);

				string configFile = ConfigFileTextBox.Text.Trim();
				if (!Path.IsPathFullyQualified(configFile))
					configFile = Path.GetFullPath(Constants.SystemRootPath + configFile);

				// Keep this one relative to the current working dir.
				// We don't have permission to put data in the install location usually.
				string outputFile = OutputFileTextBox.Text.Trim();
				if (!Path.IsPathFullyQualified(outputFile))
					outputFile = Path.GetFullPath(outputFile);

				if (!string.IsNullOrWhiteSpace(inputFile)
					&& File.Exists(inputFile)
					&& YearCheckbox.Checked
					&& !string.IsNullOrWhiteSpace(configFile)
					&& File.Exists(configFile)
					&& !string.IsNullOrWhiteSpace(outputFile))
				{
					char delimiter;
					if (FieldDelimiterComboBox.SelectedItem.ToString() == "TAB")
						delimiter = Constants.Delimiters.TabChar;
					else
						delimiter = FieldDelimiterComboBox.SelectedItem.ToString().First();

					int guidelineYear = Convert.ToInt32(GuidelineYearUpDown.Value);

					if (Worker == null)
					{
						// Setup for first use.
						Worker = new BackgroundWorker
						{
							WorkerReportsProgress = true,
							WorkerSupportsCancellation = true
						};
						Worker.DoWork += IO_Library.InterpretDataFile;
						Worker.RunWorkerCompleted += HandlerInterpretationCompletion;
						Worker.ProgressChanged += ProgressMeterEventHandler;
					}

					FileInterpretationParameters args =
						new(inputFile, delimiter, guidelineYear, configFile,
						outputFile, Worker);

					Worker.RunWorkerAsync(args);
				}
				else
				{
					MessageBox.Show("Please check the file names or guideline year selection.");
					ToggleUI(true);
				}
			}
			catch
			{
				// Ensure that user control returns if there's an exception.
				ToggleUI(true);
				throw;
			}
		}

		private void HandlerInterpretationCompletion(object s, RunWorkerCompletedEventArgs e)
		{
			// No message is required if the user cancelled the operation.
			if (!e.Cancelled)
			{
				if (e.Error != null)
					MessageBox.Show(e.Error.Message);

				else
					MessageBox.Show("Interpretation completed.");
			}

			ToggleUI(true);
		}

		private void GetInerpretationsButton_Click(object sender, EventArgs e)
		{
			if (ValidateSelectionsForInterpretation(true))
			{
				// Recalculate the breakpoints based on the current option set.
				AntibioticSpecificInterpretationRules.ClearBreakpoints();

				InterpretationConfiguration interpretationConfig = new();

				interpretationConfig.IncludeInterpretationComments = IncludeInterpretationCommentsCheckbox.Checked;
				interpretationConfig.PrioritizedBreakpointTypes = new();
				if (BreakpointTypesCheckbox.Checked)
					foreach (string item in BreakpointTypesCheckedListBox.CheckedItems)
						interpretationConfig.PrioritizedBreakpointTypes.Add(item);
				else
					interpretationConfig.PrioritizedBreakpointTypes.Add(Breakpoint.BreakpointTypes.Human);

				if (SitesOfInfectionCheckbox.Checked)
				{
					interpretationConfig.PrioritizedSitesOfInfection = new();
					foreach (string item in SitesOfInfectionCheckedListBox.CheckedItems)
						interpretationConfig.PrioritizedSitesOfInfection.Add(item);
				}

				interpretationConfig.GuidelineYear = Convert.ToInt64(GuidelineYearUpDown.Value);

				string orgCode = WHONET_OrgCode.Text.Trim();

				string antibioticCode =
						AntimicrobialCodesTextBox.Text.Trim().Split(Constants.Delimiters.CommaChar).Select((abx) => abx.Trim()).First();

				string measurement = ResultStringTextBox.Text;

				string interpretation =
					IsolateInterpretation.GetSingleInterpretation(
						interpretationConfig, orgCode, antibioticCode, measurement);

				if (!interpretationConfig.IncludeInterpretationComments)
					interpretation = IsolateInterpretation.RemoveComments(interpretation);

				MessageBox.Show(interpretation);
			}
			else
			{
				MessageBox.Show(Translations.Resources.OneOrMoreSelectionsIsInvalid);
			}
		}

		private void GetApplicableBreakpointsButton_Click(object sender, EventArgs e)
		{
			if (ValidateSelectionsForBreakpoints(true))
			{
				List<string> prioritizedGuidelines = null;
				List<int> prioritizedGuidelineYears = null;
				List<string> prioritizedBreakpointTypes = null;
				List<string> prioritizedSitesOfInfection = null;
				string orgCode = WHONET_OrgCode.Text.Trim();
				List<string> prioritizedWhonetAbxFullDrugCodes = null;

				if (GuidelinesCheckbox.Checked)
				{
					prioritizedGuidelines = new();
					foreach (string item in SelectedGuidelinesCheckedListBox.CheckedItems)
						prioritizedGuidelines.Add(item);
				}

				if (BreakpointTypesCheckbox.Checked)
				{
					prioritizedBreakpointTypes = new();
					foreach (string item in BreakpointTypesCheckedListBox.CheckedItems)
						prioritizedBreakpointTypes.Add(item);
				}

				if (SitesOfInfectionCheckbox.Checked)
				{
					prioritizedSitesOfInfection = new();
					foreach (string item in SitesOfInfectionCheckedListBox.CheckedItems)
						prioritizedSitesOfInfection.Add(item);
				}

				if (YearCheckbox.Checked)
				{
					prioritizedGuidelineYears = new();
					prioritizedGuidelineYears.Add(Convert.ToInt32(GuidelineYearUpDown.Value));
				}

				if (!string.IsNullOrWhiteSpace(AntimicrobialCodesTextBox.Text))
				{
					prioritizedWhonetAbxFullDrugCodes = AntimicrobialCodesTextBox.Text.Trim().Split(Constants.Delimiters.CommaChar).Select((abx) => abx.Trim()).ToList();
				}

				List<Breakpoint> applicableBreakpoints =
					Breakpoint.GetApplicableBreakpoints(
						orgCode,
						new List<Breakpoint>(),
						prioritizedGuidelines: prioritizedGuidelines,
						prioritizedGuidelineYears: prioritizedGuidelineYears,
						prioritizedBreakpointTypes: prioritizedBreakpointTypes,
						prioritizedSitesOfInfection: prioritizedSitesOfInfection,
						prioritizedWhonetAbxFullDrugCodes: prioritizedWhonetAbxFullDrugCodes);

				using Interpretation_Interface.BreakpointDisplay bp = new(applicableBreakpoints);
				bp.ShowDialog();
			}
			else
			{
				MessageBox.Show("One or more selections is invalid.");
			}
		}

		private void GetApplicableExpertRulesButton_Click(object sender, EventArgs e)
		{
			if (ValidateSelectionsForExpertRules())
			{
				string orgCode = WHONET_OrgCode.Text.Trim();

				string[] abxAndTests = AntimicrobialCodesTextBox.Text.Trim().Split(Constants.Delimiters.CommaChar).Select((abx) => abx.Trim()).ToArray();
				List<string> antibioticCodes = abxAndTests.Where(abx => IsolateInterpretation.ValidAntibioticCode.IsMatch(abx)).ToList();
				List<string> otherTestsCodes = abxAndTests.Except(antibioticCodes).ToList();

				List<ExpertInterpretationRule> expertRules =
					ExpertInterpretationRule.GetApplicableExpertRules(orgCode, antibioticCodes, otherTestsCodes, ExpertInterpretationRule.RuleCodes.All);

				using Interpretation_Interface.ExpertRuleDisplay expertRuleDisplay = new(expertRules);
				expertRuleDisplay.ShowDialog();
			}
			else MessageBox.Show(Translations.Resources.OneOrMoreSelectionsIsInvalid);
		}

		private void GetApplicableIntrinsicResistanceRulesButton_Click(object sender, EventArgs e)
		{
			if (ValidateCommonSelections(true))
			{
				string orgCode = WHONET_OrgCode.Text.Trim();

				List<string> prioritizedGuidelines = null;
				if (GuidelinesCheckbox.Checked)
				{
					prioritizedGuidelines = new();
					foreach (string item in SelectedGuidelinesCheckedListBox.CheckedItems)
						prioritizedGuidelines.Add(item);
				}

				IEnumerable<ExpectedResistancePhenotypeRule> applicableIntrinsicRules =
					ExpectedResistancePhenotypeRule.GetApplicableExpectedResistanceRules(orgCode, prioritizedGuidelines: prioritizedGuidelines);

				using Interpretation_Interface.IntrinsicRuleDisplay ir = new(applicableIntrinsicRules);
				ir.ShowDialog();
			}
			else
			{
				MessageBox.Show(Translations.Resources.OneOrMoreSelectionsIsInvalid);
			}
		}

		private void GuidelinesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			SelectedGuidelinesCheckedListBox.Enabled = cb.Checked;
		}

		private void YearCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			GuidelineYearUpDown.Enabled = cb.Checked;
		}

		private void BreakpointTypesCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			BreakpointTypesCheckedListBox.Enabled = cb.Checked;
		}

		private void SiteOfInfectionCheckbox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox cb = (CheckBox)sender;
			SitesOfInfectionCheckedListBox.Enabled = cb.Checked;
		}

		private void BrowseForInputFileButton_Click(object sender, EventArgs e)
		{
			using OpenFileDialog openFile = new();
			if (openFile.ShowDialog() == DialogResult.OK)
				InputFileTextBox.Text = openFile.FileName;
		}


		private void BrowseForConfigFileButton_Click(object sender, EventArgs e)
		{
			using OpenFileDialog openFile = new();
			if (openFile.ShowDialog() == DialogResult.OK)
				ConfigFileTextBox.Text = openFile.FileName;
		}

		private void BrowseForOutputFileButton_Click(object sender, EventArgs e)
		{
			using SaveFileDialog saveFile = new()
			{
				Filter = string.Format("{0} (*.txt)|*.txt|{1} (*.*)|*.*",
				Translations.Resources.TextFiles,
				Translations.Resources.AllFiles)
			};

			if (saveFile.ShowDialog() == DialogResult.OK)
				OutputFileTextBox.Text = saveFile.FileName;
		}

		private void ProgressMeterEventHandler(object s, ProgressChangedEventArgs e)
		{
			ProgressMeter.Value = e.ProgressPercentage;
		}

		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			if (Worker != null && Worker.IsBusy)
				Worker.CancelAsync();
		}

		private void TestMethodChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = sender as RadioButton;
			DiskContentComboBox.Enabled = radioButton.Checked;
		}

		private void SearchTextChanged(object sender, EventArgs e)
		{
			TextBox searchTextBox = sender as TextBox;
			ComboBox searchComboBox = searchTextBox.Tag as ComboBox;

			SearchList(searchComboBox, searchTextBox.Text);
		}

		#endregion

		#region Library

		private void SearchList(ComboBox targetControl, string searchString)
		{
			List<Tuple<string, string>> fullList = 
				targetControl.Tag as List<Tuple<string, string>>;

			if (string.IsNullOrWhiteSpace(searchString))
			{
				// No search terms. Reset the list.
				targetControl.DataSource = fullList;
			}
			else
			{
				// Filter the items using the search terms provided by the user.
				List<string> searchTerms =
					searchString.Split(' ').
					Where(s => !string.IsNullOrWhiteSpace(s)).
					Distinct(StringComparer.InvariantCultureIgnoreCase).
					ToList();

				List<Tuple<string, string>> filteredList =
					fullList.Skip(1).
					Where(item => searchTerms.All(s => item.Item1.Contains(s, StringComparison.InvariantCultureIgnoreCase) || item.Item2.Contains(s, StringComparison.InvariantCultureIgnoreCase))).
					ToList();

				targetControl.DataSource = filteredList;
			}
		}

		private bool ValidateCommonSelections(bool organismCodeRequired)
		{
			if (GuidelinesCheckbox.Checked && SelectedGuidelinesCheckedListBox.CheckedItems.Count == 0)
				return false;
			else
				return !organismCodeRequired || WHONET_OrgCode.Text.Trim().Length == 3;
		}

		private bool ValidateSelectionsForBreakpoints(bool organismCodeRequired)
		{
			if (!ValidateCommonSelections(organismCodeRequired))
				return false;
			else if (BreakpointTypesCheckbox.Checked && BreakpointTypesCheckedListBox.CheckedItems.Count == 0)
				return false;
			else if (SitesOfInfectionCheckbox.Checked && SitesOfInfectionCheckedListBox.CheckedItems.Count == 0)
				return false;

			else
				return true;
		}

		private bool ValidateSelectionsForInterpretation(bool organismCodeRequired)
		{
			if (!ValidateSelectionsForBreakpoints(organismCodeRequired))
				return false;
			else if (!YearCheckbox.Checked)
				return false;
			else if (string.IsNullOrWhiteSpace(AntimicrobialCodesTextBox.Text))
				return false;
			else if (string.IsNullOrWhiteSpace(ResultStringTextBox.Text))
				return false;
			else
				return true;
		}

		private bool ValidateSelectionsForExpertRules()
		{
			return WHONET_OrgCode.Text.Trim().Length == 3 && !string.IsNullOrWhiteSpace(AntimicrobialCodesTextBox.Text);
		}

		private void ToggleUI(bool enabled)
		{
			YearCheckbox.Enabled = enabled;
			GuidelineYearUpDown.Enabled = enabled;
			Cancel_Button.Enabled = !enabled;
			ModeTabControl.Enabled = enabled;
		}

		#endregion
	}
}
