using System.Collections.Generic;
using System.Windows.Forms;

namespace Interpretation_Interface
{
	public partial class BreakpointDisplay : Form
	{
		public BreakpointDisplay(List<AMR_Engine.Breakpoint> breakpoints)
		{
			InitializeComponent();

			BreakpointsDataGridView.DataSource = AMR_Engine.Breakpoint.CreateTableFromArray(breakpoints);
			Text = string.Format("Matching breakpoints: {0}", breakpoints.Count);

			// Disable sorting. The order is important.
			foreach (DataGridViewColumn c in BreakpointsDataGridView.Columns)
				c.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
	}
}
