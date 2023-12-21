
namespace Interpretation_Interface
{
	partial class ExpertRuleDisplay
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertRuleDisplay));
			this.ExpertRulesDataGridView = new Interpretation_Interface.DoubleBufferedDataGridView();
			this.Cancel_Button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ExpertRulesDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// ExpertRulesDataGridView
			// 
			this.ExpertRulesDataGridView.AllowUserToAddRows = false;
			this.ExpertRulesDataGridView.AllowUserToDeleteRows = false;
			this.ExpertRulesDataGridView.AllowUserToResizeRows = false;
			this.ExpertRulesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ExpertRulesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.ExpertRulesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ExpertRulesDataGridView.Location = new System.Drawing.Point(12, 12);
			this.ExpertRulesDataGridView.Name = "ExpertRulesDataGridView";
			this.ExpertRulesDataGridView.ReadOnly = true;
			this.ExpertRulesDataGridView.RowHeadersVisible = false;
			this.ExpertRulesDataGridView.RowTemplate.Height = 25;
			this.ExpertRulesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.ExpertRulesDataGridView.Size = new System.Drawing.Size(868, 374);
			this.ExpertRulesDataGridView.TabIndex = 1;
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
			// ExpertRuleDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(892, 427);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.ExpertRulesDataGridView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ExpertRuleDisplay";
			this.Text = "ExpertRuleDisplay";
			((System.ComponentModel.ISupportInitialize)(this.ExpertRulesDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DoubleBufferedDataGridView ExpertRulesDataGridView;
		private System.Windows.Forms.Button Cancel_Button;
	}
}