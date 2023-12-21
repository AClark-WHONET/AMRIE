
namespace AMR_InterpretationInterface
{
	partial class MainApplicationForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApplicationForm));
			this.GetApplicableBreakpointsButton = new System.Windows.Forms.Button();
			this.WHONET_OrgCode = new System.Windows.Forms.TextBox();
			this.OrganismCodeLabel = new System.Windows.Forms.Label();
			this.GuidelinesCheckbox = new System.Windows.Forms.CheckBox();
			this.SelectedGuidelinesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.YearCheckbox = new System.Windows.Forms.CheckBox();
			this.GuidelineYearUpDown = new System.Windows.Forms.NumericUpDown();
			this.BreakpointTypesCheckbox = new System.Windows.Forms.CheckBox();
			this.BreakpointTypesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.SitesOfInfectionCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.SitesOfInfectionCheckbox = new System.Windows.Forms.CheckBox();
			this.AntimicrobialFullCodesLabel = new System.Windows.Forms.Label();
			this.AntimicrobialCodesTextBox = new System.Windows.Forms.TextBox();
			this.GetApplicableIntrinsicResistanceRulesButton = new System.Windows.Forms.Button();
			this.GetInerpretationsButton = new System.Windows.Forms.Button();
			this.ResultStringTextBox = new System.Windows.Forms.TextBox();
			this.ResultLabel = new System.Windows.Forms.Label();
			this.ModeTabControl = new System.Windows.Forms.TabControl();
			this.MultipleInterpretationsTab = new System.Windows.Forms.TabPage();
			this.ProgressMeter = new System.Windows.Forms.ProgressBar();
			this.BrowseForConfigFileButton = new System.Windows.Forms.Button();
			this.ConfigFileTextBox = new System.Windows.Forms.TextBox();
			this.ConfigFileLabel = new System.Windows.Forms.Label();
			this.BrowseForOutputFileButton = new System.Windows.Forms.Button();
			this.OutputFileTextBox = new System.Windows.Forms.TextBox();
			this.OutputFileNameLabel = new System.Windows.Forms.Label();
			this.FieldDelimiterComboBox = new System.Windows.Forms.ComboBox();
			this.FieldDelimiterLabel = new System.Windows.Forms.Label();
			this.InterpretFileButton = new System.Windows.Forms.Button();
			this.BrowseForInputFileButton = new System.Windows.Forms.Button();
			this.InputFileTextBox = new System.Windows.Forms.TextBox();
			this.InputFileNameLabel = new System.Windows.Forms.Label();
			this.SingleInterpretationTab = new System.Windows.Forms.TabPage();
			this.IncludeInterpretationCommentsCheckbox = new System.Windows.Forms.CheckBox();
			this.GetApplicableExpertRulesButton = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.GuidelineYearUpDown)).BeginInit();
			this.ModeTabControl.SuspendLayout();
			this.MultipleInterpretationsTab.SuspendLayout();
			this.SingleInterpretationTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// GetApplicableBreakpointsButton
			// 
			this.GetApplicableBreakpointsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GetApplicableBreakpointsButton.Location = new System.Drawing.Point(6, 202);
			this.GetApplicableBreakpointsButton.Name = "GetApplicableBreakpointsButton";
			this.GetApplicableBreakpointsButton.Size = new System.Drawing.Size(251, 23);
			this.GetApplicableBreakpointsButton.TabIndex = 11;
			this.GetApplicableBreakpointsButton.Text = "Get applicable breakpoints";
			this.GetApplicableBreakpointsButton.UseVisualStyleBackColor = true;
			this.GetApplicableBreakpointsButton.Click += new System.EventHandler(this.GetApplicableBreakpointsButton_Click);
			// 
			// WHONET_OrgCode
			// 
			this.WHONET_OrgCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.WHONET_OrgCode.Location = new System.Drawing.Point(238, 115);
			this.WHONET_OrgCode.MaxLength = 3;
			this.WHONET_OrgCode.Name = "WHONET_OrgCode";
			this.WHONET_OrgCode.Size = new System.Drawing.Size(55, 23);
			this.WHONET_OrgCode.TabIndex = 7;
			// 
			// OrganismCodeLabel
			// 
			this.OrganismCodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OrganismCodeLabel.AutoSize = true;
			this.OrganismCodeLabel.Location = new System.Drawing.Point(6, 118);
			this.OrganismCodeLabel.Name = "OrganismCodeLabel";
			this.OrganismCodeLabel.Size = new System.Drawing.Size(139, 15);
			this.OrganismCodeLabel.TabIndex = 2;
			this.OrganismCodeLabel.Text = "WHONET organism code";
			// 
			// GuidelinesCheckbox
			// 
			this.GuidelinesCheckbox.AutoSize = true;
			this.GuidelinesCheckbox.Checked = true;
			this.GuidelinesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.GuidelinesCheckbox.Location = new System.Drawing.Point(6, 6);
			this.GuidelinesCheckbox.Name = "GuidelinesCheckbox";
			this.GuidelinesCheckbox.Size = new System.Drawing.Size(122, 19);
			this.GuidelinesCheckbox.TabIndex = 1;
			this.GuidelinesCheckbox.Text = "Restrict guidelines";
			this.GuidelinesCheckbox.UseVisualStyleBackColor = true;
			this.GuidelinesCheckbox.CheckedChanged += new System.EventHandler(this.GuidelinesCheckbox_CheckedChanged);
			// 
			// SelectedGuidelinesCheckedListBox
			// 
			this.SelectedGuidelinesCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
			this.SelectedGuidelinesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SelectedGuidelinesCheckedListBox.CheckOnClick = true;
			this.SelectedGuidelinesCheckedListBox.FormattingEnabled = true;
			this.SelectedGuidelinesCheckedListBox.Items.AddRange(new object[] {
            "CLSI",
            "EUCAST",
            "SFM"});
			this.SelectedGuidelinesCheckedListBox.Location = new System.Drawing.Point(15, 31);
			this.SelectedGuidelinesCheckedListBox.Name = "SelectedGuidelinesCheckedListBox";
			this.SelectedGuidelinesCheckedListBox.Size = new System.Drawing.Size(139, 54);
			this.SelectedGuidelinesCheckedListBox.TabIndex = 2;
			// 
			// YearCheckbox
			// 
			this.YearCheckbox.Checked = true;
			this.YearCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.YearCheckbox.Location = new System.Drawing.Point(12, 13);
			this.YearCheckbox.Name = "YearCheckbox";
			this.YearCheckbox.Size = new System.Drawing.Size(236, 19);
			this.YearCheckbox.TabIndex = 5;
			this.YearCheckbox.Text = "Restrict guideline year";
			this.YearCheckbox.UseVisualStyleBackColor = true;
			this.YearCheckbox.CheckedChanged += new System.EventHandler(this.YearCheckbox_CheckedChanged);
			// 
			// GuidelineYearUpDown
			// 
			this.GuidelineYearUpDown.Location = new System.Drawing.Point(254, 12);
			this.GuidelineYearUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.GuidelineYearUpDown.Minimum = new decimal(new int[] {
            2011,
            0,
            0,
            0});
			this.GuidelineYearUpDown.Name = "GuidelineYearUpDown";
			this.GuidelineYearUpDown.Size = new System.Drawing.Size(55, 23);
			this.GuidelineYearUpDown.TabIndex = 6;
			this.GuidelineYearUpDown.Value = new decimal(new int[] {
            2011,
            0,
            0,
            0});
			// 
			// BreakpointTypesCheckbox
			// 
			this.BreakpointTypesCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.BreakpointTypesCheckbox.Location = new System.Drawing.Point(225, 6);
			this.BreakpointTypesCheckbox.Name = "BreakpointTypesCheckbox";
			this.BreakpointTypesCheckbox.Size = new System.Drawing.Size(224, 19);
			this.BreakpointTypesCheckbox.TabIndex = 3;
			this.BreakpointTypesCheckbox.Text = "Restrict breakpoint types";
			this.BreakpointTypesCheckbox.UseVisualStyleBackColor = true;
			this.BreakpointTypesCheckbox.CheckedChanged += new System.EventHandler(this.BreakpointTypesCheckbox_CheckedChanged);
			// 
			// BreakpointTypesCheckedListBox
			// 
			this.BreakpointTypesCheckedListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.BreakpointTypesCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
			this.BreakpointTypesCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.BreakpointTypesCheckedListBox.CheckOnClick = true;
			this.BreakpointTypesCheckedListBox.Enabled = false;
			this.BreakpointTypesCheckedListBox.FormattingEnabled = true;
			this.BreakpointTypesCheckedListBox.Items.AddRange(new object[] {
            "Human",
            "Animal",
            "ECOFF"});
			this.BreakpointTypesCheckedListBox.Location = new System.Drawing.Point(243, 31);
			this.BreakpointTypesCheckedListBox.Name = "BreakpointTypesCheckedListBox";
			this.BreakpointTypesCheckedListBox.Size = new System.Drawing.Size(209, 54);
			this.BreakpointTypesCheckedListBox.TabIndex = 4;
			// 
			// SitesOfInfectionCheckedListBox
			// 
			this.SitesOfInfectionCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SitesOfInfectionCheckedListBox.BackColor = System.Drawing.SystemColors.Control;
			this.SitesOfInfectionCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SitesOfInfectionCheckedListBox.CheckOnClick = true;
			this.SitesOfInfectionCheckedListBox.Enabled = false;
			this.SitesOfInfectionCheckedListBox.FormattingEnabled = true;
			this.SitesOfInfectionCheckedListBox.Location = new System.Drawing.Point(514, 31);
			this.SitesOfInfectionCheckedListBox.Name = "SitesOfInfectionCheckedListBox";
			this.SitesOfInfectionCheckedListBox.Size = new System.Drawing.Size(209, 108);
			this.SitesOfInfectionCheckedListBox.TabIndex = 6;
			// 
			// SitesOfInfectionCheckbox
			// 
			this.SitesOfInfectionCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SitesOfInfectionCheckbox.Location = new System.Drawing.Point(499, 6);
			this.SitesOfInfectionCheckbox.Name = "SitesOfInfectionCheckbox";
			this.SitesOfInfectionCheckbox.Size = new System.Drawing.Size(224, 19);
			this.SitesOfInfectionCheckbox.TabIndex = 5;
			this.SitesOfInfectionCheckbox.Text = "Restrict sites of infection";
			this.SitesOfInfectionCheckbox.UseVisualStyleBackColor = true;
			this.SitesOfInfectionCheckbox.CheckedChanged += new System.EventHandler(this.SiteOfInfectionCheckbox_CheckedChanged);
			// 
			// AntimicrobialFullCodesLabel
			// 
			this.AntimicrobialFullCodesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AntimicrobialFullCodesLabel.AutoSize = true;
			this.AntimicrobialFullCodesLabel.Location = new System.Drawing.Point(6, 147);
			this.AntimicrobialFullCodesLabel.Name = "AntimicrobialFullCodesLabel";
			this.AntimicrobialFullCodesLabel.Size = new System.Drawing.Size(106, 15);
			this.AntimicrobialFullCodesLabel.TabIndex = 12;
			this.AntimicrobialFullCodesLabel.Text = "Antibiotic code list";
			// 
			// AntimicrobialCodesTextBox
			// 
			this.AntimicrobialCodesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AntimicrobialCodesTextBox.Location = new System.Drawing.Point(238, 144);
			this.AntimicrobialCodesTextBox.Name = "AntimicrobialCodesTextBox";
			this.AntimicrobialCodesTextBox.Size = new System.Drawing.Size(480, 23);
			this.AntimicrobialCodesTextBox.TabIndex = 8;
			// 
			// GetApplicableIntrinsicResistanceRulesButton
			// 
			this.GetApplicableIntrinsicResistanceRulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.GetApplicableIntrinsicResistanceRulesButton.Location = new System.Drawing.Point(469, 202);
			this.GetApplicableIntrinsicResistanceRulesButton.Name = "GetApplicableIntrinsicResistanceRulesButton";
			this.GetApplicableIntrinsicResistanceRulesButton.Size = new System.Drawing.Size(254, 23);
			this.GetApplicableIntrinsicResistanceRulesButton.TabIndex = 13;
			this.GetApplicableIntrinsicResistanceRulesButton.Text = "Get applicable intrinsic resistance";
			this.GetApplicableIntrinsicResistanceRulesButton.UseVisualStyleBackColor = true;
			this.GetApplicableIntrinsicResistanceRulesButton.Click += new System.EventHandler(this.GetApplicableIntrinsicResistanceRulesButton_Click);
			// 
			// GetInerpretationsButton
			// 
			this.GetInerpretationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.GetInerpretationsButton.Location = new System.Drawing.Point(469, 231);
			this.GetInerpretationsButton.Name = "GetInerpretationsButton";
			this.GetInerpretationsButton.Size = new System.Drawing.Size(254, 23);
			this.GetInerpretationsButton.TabIndex = 14;
			this.GetInerpretationsButton.Text = "Get interpretations";
			this.GetInerpretationsButton.UseVisualStyleBackColor = true;
			this.GetInerpretationsButton.Click += new System.EventHandler(this.GetInerpretationsButton_Click);
			// 
			// ResultStringTextBox
			// 
			this.ResultStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ResultStringTextBox.Location = new System.Drawing.Point(238, 173);
			this.ResultStringTextBox.Name = "ResultStringTextBox";
			this.ResultStringTextBox.Size = new System.Drawing.Size(55, 23);
			this.ResultStringTextBox.TabIndex = 9;
			// 
			// ResultLabel
			// 
			this.ResultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ResultLabel.AutoSize = true;
			this.ResultLabel.Location = new System.Drawing.Point(6, 176);
			this.ResultLabel.Name = "ResultLabel";
			this.ResultLabel.Size = new System.Drawing.Size(72, 15);
			this.ResultLabel.TabIndex = 44;
			this.ResultLabel.Text = "Result string";
			// 
			// ModeTabControl
			// 
			this.ModeTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ModeTabControl.Controls.Add(this.MultipleInterpretationsTab);
			this.ModeTabControl.Controls.Add(this.SingleInterpretationTab);
			this.ModeTabControl.Location = new System.Drawing.Point(12, 41);
			this.ModeTabControl.MinimumSize = new System.Drawing.Size(737, 288);
			this.ModeTabControl.Name = "ModeTabControl";
			this.ModeTabControl.SelectedIndex = 0;
			this.ModeTabControl.Size = new System.Drawing.Size(737, 288);
			this.ModeTabControl.TabIndex = 0;
			// 
			// MultipleInterpretationsTab
			// 
			this.MultipleInterpretationsTab.Controls.Add(this.ProgressMeter);
			this.MultipleInterpretationsTab.Controls.Add(this.BrowseForConfigFileButton);
			this.MultipleInterpretationsTab.Controls.Add(this.ConfigFileTextBox);
			this.MultipleInterpretationsTab.Controls.Add(this.ConfigFileLabel);
			this.MultipleInterpretationsTab.Controls.Add(this.BrowseForOutputFileButton);
			this.MultipleInterpretationsTab.Controls.Add(this.OutputFileTextBox);
			this.MultipleInterpretationsTab.Controls.Add(this.OutputFileNameLabel);
			this.MultipleInterpretationsTab.Controls.Add(this.FieldDelimiterComboBox);
			this.MultipleInterpretationsTab.Controls.Add(this.FieldDelimiterLabel);
			this.MultipleInterpretationsTab.Controls.Add(this.InterpretFileButton);
			this.MultipleInterpretationsTab.Controls.Add(this.BrowseForInputFileButton);
			this.MultipleInterpretationsTab.Controls.Add(this.InputFileTextBox);
			this.MultipleInterpretationsTab.Controls.Add(this.InputFileNameLabel);
			this.MultipleInterpretationsTab.Location = new System.Drawing.Point(4, 24);
			this.MultipleInterpretationsTab.Name = "MultipleInterpretationsTab";
			this.MultipleInterpretationsTab.Padding = new System.Windows.Forms.Padding(3);
			this.MultipleInterpretationsTab.Size = new System.Drawing.Size(729, 260);
			this.MultipleInterpretationsTab.TabIndex = 0;
			this.MultipleInterpretationsTab.Text = "Whole-database interpretation";
			this.MultipleInterpretationsTab.UseVisualStyleBackColor = true;
			// 
			// ProgressMeter
			// 
			this.ProgressMeter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ProgressMeter.Location = new System.Drawing.Point(6, 231);
			this.ProgressMeter.Name = "ProgressMeter";
			this.ProgressMeter.Size = new System.Drawing.Size(164, 23);
			this.ProgressMeter.TabIndex = 11;
			// 
			// BrowseForConfigFileButton
			// 
			this.BrowseForConfigFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseForConfigFileButton.Location = new System.Drawing.Point(622, 64);
			this.BrowseForConfigFileButton.Name = "BrowseForConfigFileButton";
			this.BrowseForConfigFileButton.Size = new System.Drawing.Size(101, 23);
			this.BrowseForConfigFileButton.TabIndex = 7;
			this.BrowseForConfigFileButton.Text = "Browse";
			this.BrowseForConfigFileButton.UseVisualStyleBackColor = true;
			this.BrowseForConfigFileButton.Click += new System.EventHandler(this.BrowseForConfigFileButton_Click);
			// 
			// ConfigFileTextBox
			// 
			this.ConfigFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConfigFileTextBox.Location = new System.Drawing.Point(111, 65);
			this.ConfigFileTextBox.Name = "ConfigFileTextBox";
			this.ConfigFileTextBox.Size = new System.Drawing.Size(505, 23);
			this.ConfigFileTextBox.TabIndex = 6;
			this.ConfigFileTextBox.Text = "Resources\\SampleConfig.json";
			// 
			// ConfigFileLabel
			// 
			this.ConfigFileLabel.AutoSize = true;
			this.ConfigFileLabel.Location = new System.Drawing.Point(6, 68);
			this.ConfigFileLabel.Name = "ConfigFileLabel";
			this.ConfigFileLabel.Size = new System.Drawing.Size(62, 15);
			this.ConfigFileLabel.TabIndex = 9;
			this.ConfigFileLabel.Text = "Config file";
			// 
			// BrowseForOutputFileButton
			// 
			this.BrowseForOutputFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseForOutputFileButton.Location = new System.Drawing.Point(622, 93);
			this.BrowseForOutputFileButton.Name = "BrowseForOutputFileButton";
			this.BrowseForOutputFileButton.Size = new System.Drawing.Size(101, 23);
			this.BrowseForOutputFileButton.TabIndex = 9;
			this.BrowseForOutputFileButton.Text = "Browse";
			this.BrowseForOutputFileButton.UseVisualStyleBackColor = true;
			this.BrowseForOutputFileButton.Click += new System.EventHandler(this.BrowseForOutputFileButton_Click);
			// 
			// OutputFileTextBox
			// 
			this.OutputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputFileTextBox.Location = new System.Drawing.Point(111, 94);
			this.OutputFileTextBox.Name = "OutputFileTextBox";
			this.OutputFileTextBox.Size = new System.Drawing.Size(505, 23);
			this.OutputFileTextBox.TabIndex = 8;
			this.OutputFileTextBox.Text = "Results.txt";
			// 
			// OutputFileNameLabel
			// 
			this.OutputFileNameLabel.AutoSize = true;
			this.OutputFileNameLabel.Location = new System.Drawing.Point(6, 97);
			this.OutputFileNameLabel.Name = "OutputFileNameLabel";
			this.OutputFileNameLabel.Size = new System.Drawing.Size(64, 15);
			this.OutputFileNameLabel.TabIndex = 6;
			this.OutputFileNameLabel.Text = "Output file";
			// 
			// FieldDelimiterComboBox
			// 
			this.FieldDelimiterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FieldDelimiterComboBox.FormattingEnabled = true;
			this.FieldDelimiterComboBox.Items.AddRange(new object[] {
            "|",
            ",",
            "TAB",
            ";"});
			this.FieldDelimiterComboBox.Location = new System.Drawing.Point(111, 36);
			this.FieldDelimiterComboBox.Name = "FieldDelimiterComboBox";
			this.FieldDelimiterComboBox.Size = new System.Drawing.Size(59, 23);
			this.FieldDelimiterComboBox.TabIndex = 5;
			// 
			// FieldDelimiterLabel
			// 
			this.FieldDelimiterLabel.AutoSize = true;
			this.FieldDelimiterLabel.Location = new System.Drawing.Point(6, 39);
			this.FieldDelimiterLabel.Name = "FieldDelimiterLabel";
			this.FieldDelimiterLabel.Size = new System.Drawing.Size(82, 15);
			this.FieldDelimiterLabel.TabIndex = 4;
			this.FieldDelimiterLabel.Text = "Field delimiter";
			// 
			// InterpretFileButton
			// 
			this.InterpretFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.InterpretFileButton.Location = new System.Drawing.Point(506, 231);
			this.InterpretFileButton.Name = "InterpretFileButton";
			this.InterpretFileButton.Size = new System.Drawing.Size(217, 23);
			this.InterpretFileButton.TabIndex = 10;
			this.InterpretFileButton.Text = "Interpret file";
			this.InterpretFileButton.UseVisualStyleBackColor = true;
			this.InterpretFileButton.Click += new System.EventHandler(this.InterpretFileButton_Click);
			// 
			// BrowseForInputFileButton
			// 
			this.BrowseForInputFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BrowseForInputFileButton.Location = new System.Drawing.Point(622, 6);
			this.BrowseForInputFileButton.Name = "BrowseForInputFileButton";
			this.BrowseForInputFileButton.Size = new System.Drawing.Size(101, 23);
			this.BrowseForInputFileButton.TabIndex = 2;
			this.BrowseForInputFileButton.Text = "Browse";
			this.BrowseForInputFileButton.UseVisualStyleBackColor = true;
			this.BrowseForInputFileButton.Click += new System.EventHandler(this.BrowseForInputFileButton_Click);
			// 
			// InputFileTextBox
			// 
			this.InputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputFileTextBox.Location = new System.Drawing.Point(111, 7);
			this.InputFileTextBox.Name = "InputFileTextBox";
			this.InputFileTextBox.Size = new System.Drawing.Size(505, 23);
			this.InputFileTextBox.TabIndex = 1;
			this.InputFileTextBox.Text = "Resources\\SampleInputFile.txt";
			// 
			// InputFileNameLabel
			// 
			this.InputFileNameLabel.AutoSize = true;
			this.InputFileNameLabel.Location = new System.Drawing.Point(6, 10);
			this.InputFileNameLabel.Name = "InputFileNameLabel";
			this.InputFileNameLabel.Size = new System.Drawing.Size(54, 15);
			this.InputFileNameLabel.TabIndex = 0;
			this.InputFileNameLabel.Text = "Input file";
			// 
			// SingleInterpretationTab
			// 
			this.SingleInterpretationTab.Controls.Add(this.IncludeInterpretationCommentsCheckbox);
			this.SingleInterpretationTab.Controls.Add(this.GetApplicableExpertRulesButton);
			this.SingleInterpretationTab.Controls.Add(this.GetInerpretationsButton);
			this.SingleInterpretationTab.Controls.Add(this.BreakpointTypesCheckedListBox);
			this.SingleInterpretationTab.Controls.Add(this.SitesOfInfectionCheckedListBox);
			this.SingleInterpretationTab.Controls.Add(this.BreakpointTypesCheckbox);
			this.SingleInterpretationTab.Controls.Add(this.ResultLabel);
			this.SingleInterpretationTab.Controls.Add(this.SitesOfInfectionCheckbox);
			this.SingleInterpretationTab.Controls.Add(this.ResultStringTextBox);
			this.SingleInterpretationTab.Controls.Add(this.GetApplicableBreakpointsButton);
			this.SingleInterpretationTab.Controls.Add(this.GetApplicableIntrinsicResistanceRulesButton);
			this.SingleInterpretationTab.Controls.Add(this.AntimicrobialCodesTextBox);
			this.SingleInterpretationTab.Controls.Add(this.OrganismCodeLabel);
			this.SingleInterpretationTab.Controls.Add(this.SelectedGuidelinesCheckedListBox);
			this.SingleInterpretationTab.Controls.Add(this.AntimicrobialFullCodesLabel);
			this.SingleInterpretationTab.Controls.Add(this.GuidelinesCheckbox);
			this.SingleInterpretationTab.Controls.Add(this.WHONET_OrgCode);
			this.SingleInterpretationTab.Location = new System.Drawing.Point(4, 24);
			this.SingleInterpretationTab.Name = "SingleInterpretationTab";
			this.SingleInterpretationTab.Padding = new System.Windows.Forms.Padding(3);
			this.SingleInterpretationTab.Size = new System.Drawing.Size(729, 260);
			this.SingleInterpretationTab.TabIndex = 1;
			this.SingleInterpretationTab.Text = "Single interpretation";
			this.SingleInterpretationTab.UseVisualStyleBackColor = true;
			// 
			// IncludeInterpretationCommentsCheckbox
			// 
			this.IncludeInterpretationCommentsCheckbox.AutoSize = true;
			this.IncludeInterpretationCommentsCheckbox.Location = new System.Drawing.Point(299, 176);
			this.IncludeInterpretationCommentsCheckbox.Name = "IncludeInterpretationCommentsCheckbox";
			this.IncludeInterpretationCommentsCheckbox.Size = new System.Drawing.Size(200, 19);
			this.IncludeInterpretationCommentsCheckbox.TabIndex = 10;
			this.IncludeInterpretationCommentsCheckbox.Text = "Include interpretation comments";
			this.IncludeInterpretationCommentsCheckbox.UseVisualStyleBackColor = true;
			// 
			// GetApplicableExpertRulesButton
			// 
			this.GetApplicableExpertRulesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.GetApplicableExpertRulesButton.Location = new System.Drawing.Point(6, 231);
			this.GetApplicableExpertRulesButton.Name = "GetApplicableExpertRulesButton";
			this.GetApplicableExpertRulesButton.Size = new System.Drawing.Size(251, 23);
			this.GetApplicableExpertRulesButton.TabIndex = 12;
			this.GetApplicableExpertRulesButton.Text = "Get applicable expert rules";
			this.GetApplicableExpertRulesButton.UseVisualStyleBackColor = true;
			this.GetApplicableExpertRulesButton.Click += new System.EventHandler(this.GetApplicableExpertRulesButton_Click);
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel_Button.Location = new System.Drawing.Point(638, 12);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(111, 23);
			this.Cancel_Button.TabIndex = 7;
			this.Cancel_Button.Text = "&Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// MainApplicationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(761, 341);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.ModeTabControl);
			this.Controls.Add(this.GuidelineYearUpDown);
			this.Controls.Add(this.YearCheckbox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainApplicationForm";
			this.Text = "Antimicrobial test result interpretation system";
			this.Load += new System.EventHandler(this.MainApplicationForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.GuidelineYearUpDown)).EndInit();
			this.ModeTabControl.ResumeLayout(false);
			this.MultipleInterpretationsTab.ResumeLayout(false);
			this.MultipleInterpretationsTab.PerformLayout();
			this.SingleInterpretationTab.ResumeLayout(false);
			this.SingleInterpretationTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button GetApplicableBreakpointsButton;
		private System.Windows.Forms.TextBox WHONET_OrgCode;
		private System.Windows.Forms.Label OrganismCodeLabel;
		private System.Windows.Forms.CheckBox GuidelinesCheckbox;
		private System.Windows.Forms.CheckedListBox SelectedGuidelinesCheckedListBox;
		private System.Windows.Forms.CheckBox YearCheckbox;
		private System.Windows.Forms.NumericUpDown GuidelineYearUpDown;
		private System.Windows.Forms.CheckBox BreakpointTypesCheckbox;
		private System.Windows.Forms.CheckedListBox BreakpointTypesCheckedListBox;
		private System.Windows.Forms.CheckedListBox SitesOfInfectionCheckedListBox;
		private System.Windows.Forms.CheckBox SitesOfInfectionCheckbox;
		private System.Windows.Forms.Label AntimicrobialFullCodesLabel;
		private System.Windows.Forms.TextBox AntimicrobialCodesTextBox;
		private System.Windows.Forms.Button GetApplicableIntrinsicResistanceRulesButton;
		private System.Windows.Forms.Button GetInerpretationsButton;
		private System.Windows.Forms.TextBox ResultStringTextBox;
		private System.Windows.Forms.Label ResultLabel;
		private System.Windows.Forms.TabControl ModeTabControl;
		private System.Windows.Forms.TabPage MultipleInterpretationsTab;
		private System.Windows.Forms.TabPage SingleInterpretationTab;
		private System.Windows.Forms.Label InputFileNameLabel;
		private System.Windows.Forms.TextBox InputFileTextBox;
		private System.Windows.Forms.Button BrowseForInputFileButton;
		private System.Windows.Forms.Button InterpretFileButton;
		private System.Windows.Forms.Label FieldDelimiterLabel;
		private System.Windows.Forms.ComboBox FieldDelimiterComboBox;
		private System.Windows.Forms.Button Cancel_Button;
		private System.Windows.Forms.Button BrowseForOutputFileButton;
		private System.Windows.Forms.TextBox OutputFileTextBox;
		private System.Windows.Forms.Label OutputFileNameLabel;
		private System.Windows.Forms.Button BrowseForConfigFileButton;
		private System.Windows.Forms.TextBox ConfigFileTextBox;
		private System.Windows.Forms.Label ConfigFileLabel;
		private System.Windows.Forms.ProgressBar ProgressMeter;
		private System.Windows.Forms.Button GetApplicableExpertRulesButton;
		private System.Windows.Forms.CheckBox IncludeInterpretationCommentsCheckbox;
	}
}

