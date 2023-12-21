using System.Collections.Generic;
using System.Windows.Forms;

namespace Interpretation_Interface
{
	public partial class ExpertRuleDisplay : Form
	{
		public ExpertRuleDisplay(List<AMR_Engine.ExpertInterpretationRule> expertRules)
		{
			InitializeComponent();

			ExpertRulesDataGridView.DataSource = 
				AMR_Engine.ExpertInterpretationRule.CreateTableFromArray(expertRules);

			Text = string.Format("Matching expert rules: {0}", expertRules.Count);
		}
	}
}
