
namespace Interpretation_Interface
{
	partial class FileInterpretationsDisplay
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileInterpretationsDisplay));
			this.ResultsGrid = new Interpretation_Interface.DoubleBufferedDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// ResultsGrid
			// 
			this.ResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ResultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsGrid.Location = new System.Drawing.Point(0, 0);
			this.ResultsGrid.Name = "ResultsGrid";
			this.ResultsGrid.RowTemplate.Height = 25;
			this.ResultsGrid.Size = new System.Drawing.Size(800, 450);
			this.ResultsGrid.TabIndex = 0;
			// 
			// FileInterpretationsDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ResultsGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FileInterpretationsDisplay";
			this.Text = "Interpretations";
			((System.ComponentModel.ISupportInitialize)(this.ResultsGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DoubleBufferedDataGridView ResultsGrid;
	}
}