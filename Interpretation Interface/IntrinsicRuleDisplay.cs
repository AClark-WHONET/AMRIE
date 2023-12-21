using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Interpretation_Interface
{
	public partial class IntrinsicRuleDisplay : Form
	{
		public IntrinsicRuleDisplay(IEnumerable<AMR_Engine.ExpectedResistancePhenotypeRule> intrinsicResistanceRules)
		{
			InitializeComponent();

			IntrinsicRulesDataGridView.DataSource = AMR_Engine.ExpectedResistancePhenotypeRule.CreateTableFromArray(intrinsicResistanceRules);
			Text = string.Format("Matching intrinsic resistance rules: {0}", intrinsicResistanceRules.Count());

			// Disable sorting. The order is important.
			foreach (DataGridViewColumn c in IntrinsicRulesDataGridView.Columns)
				c.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
	}
}
