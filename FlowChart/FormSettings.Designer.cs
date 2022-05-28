
namespace FlowChart
{
	partial class FormSettings
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
			this.nmudXSize = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblXSize = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nmudXSize)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// nmudXSize
			// 
			this.nmudXSize.Location = new System.Drawing.Point(190, 19);
			this.nmudXSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nmudXSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nmudXSize.Name = "nmudXSize";
			this.nmudXSize.Size = new System.Drawing.Size(56, 20);
			this.nmudXSize.TabIndex = 0;
			this.nmudXSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nmudXSize.ValueChanged += new System.EventHandler(this.nmudXSize_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
			this.panel1.Controls.Add(this.btnReset);
			this.panel1.Controls.Add(this.lblXSize);
			this.panel1.Controls.Add(this.nmudXSize);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(256, 337);
			this.panel1.TabIndex = 1;
			// 
			// lblXSize
			// 
			this.lblXSize.AutoSize = true;
			this.lblXSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblXSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lblXSize.Location = new System.Drawing.Point(7, 14);
			this.lblXSize.Name = "lblXSize";
			this.lblXSize.Size = new System.Drawing.Size(96, 25);
			this.lblXSize.TabIndex = 1;
			this.lblXSize.Text = "Ширина";
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnReset.Location = new System.Drawing.Point(12, 292);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(234, 33);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Сбросить настройки";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
			this.ClientSize = new System.Drawing.Size(284, 361);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(200, 200);
			this.Name = "FormSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Настройки";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FormSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.nmudXSize)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.NumericUpDown nmudXSize;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblXSize;
		private System.Windows.Forms.Button btnReset;
	}
}