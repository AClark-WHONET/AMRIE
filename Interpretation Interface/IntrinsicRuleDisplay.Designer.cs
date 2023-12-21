
namespace Interpretation_Interface
{
	partial class IntrinsicRuleDisplay
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntrinsicRuleDisplay));
			this.IntrinsicRulesDataGridView = new Interpretation_Interface.DoubleBufferedDataGridView();
			this.Cancel_Button = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.IntrinsicRulesDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// IntrinsicRulesDataGridView
			// 
			this.IntrinsicRulesDataGridView.AllowUserToAddRows = false;
			this.IntrinsicRulesDataGridView.AllowUserToDeleteRows = false;
			this.IntrinsicRulesDataGridView.AllowUserToResizeRows = false;
			this.IntrinsicRulesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.IntrinsicRulesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.IntrinsicRulesDataGridView.Location = new System.Drawing.Point(12, 12);
			this.IntrinsicRulesDataGridView.Name = "IntrinsicRulesDataGridView";
			this.IntrinsicRulesDataGridView.ReadOnly = true;
			this.IntrinsicRulesDataGridView.RowHeadersVisible = false;
			this.IntrinsicRulesDataGridView.RowTemplate.Height = 25;
			this.IntrinsicRulesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.IntrinsicRulesDataGridView.Size = new System.Drawing.Size(776, 378);
			this.IntrinsicRulesDataGridView.TabIndex = 2;
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancel_Button.Location = new System.Drawing.Point(659, 396);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(129, 23);
			this.Cancel_Button.TabIndex = 3;
			this.Cancel_Button.Text = "&Cancel";
			this.Cancel_Button.UseVisualStyleBackColor = true;
			// 
			// IntrinsicRuleDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(800, 431);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.IntrinsicRulesDataGridView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "IntrinsicRuleDisplay";
			this.Text = "Intrinsic rules";
			((System.ComponentModel.ISupportInitialize)(this.IntrinsicRulesDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DoubleBufferedDataGridView IntrinsicRulesDataGridView;
		private System.Windows.Forms.Button Cancel_Button;
	}
}