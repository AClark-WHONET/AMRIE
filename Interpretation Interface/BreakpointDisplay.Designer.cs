
namespace Interpretation_Interface
{
	partial class BreakpointDisplay
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BreakpointDisplay));
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.BreakpointsDataGridView = new Interpretation_Interface.DoubleBufferedDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.BreakpointsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel_Button.Location = new System.Drawing.Point(751, 392);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(129, 23);
			this.Cancel_Button.TabIndex = 0;
			this.Cancel_Button.Text = "&Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			// 
			// BreakpointsDataGridView
			// 
			this.BreakpointsDataGridView.AllowUserToAddRows = false;
			this.BreakpointsDataGridView.AllowUserToDeleteRows = false;
			this.BreakpointsDataGridView.AllowUserToResizeRows = false;
			this.BreakpointsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BreakpointsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.BreakpointsDataGridView.Location = new System.Drawing.Point(12, 12);
			this.BreakpointsDataGridView.Name = "BreakpointsDataGridView";
			this.BreakpointsDataGridView.ReadOnly = true;
			this.BreakpointsDataGridView.RowHeadersVisible = false;
			this.BreakpointsDataGridView.RowTemplate.Height = 25;
			this.BreakpointsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.BreakpointsDataGridView.Size = new System.Drawing.Size(868, 374);
			this.BreakpointsDataGridView.TabIndex = 1;
			// 
			// BreakpointDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(892, 427);
			this.Controls.Add(this.BreakpointsDataGridView);
			this.Controls.Add(this.Cancel_Button);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "BreakpointDisplay";
			this.Text = "Breakpoints";
			((System.ComponentModel.ISupportInitialize)(this.BreakpointsDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Cancel_Button;
		private DoubleBufferedDataGridView BreakpointsDataGridView;
	}
}