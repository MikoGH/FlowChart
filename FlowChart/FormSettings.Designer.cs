
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
            this.nmudSize = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.pctboxTest = new System.Windows.Forms.PictureBox();
            this.nmudColorB = new System.Windows.Forms.NumericUpDown();
            this.nmudColorG = new System.Windows.Forms.NumericUpDown();
            this.nmudColorR = new System.Windows.Forms.NumericUpDown();
            this.cmbParams = new System.Windows.Forms.ComboBox();
            this.cmbBlockType = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.clrd = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nmudSize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorR)).BeginInit();
            this.SuspendLayout();
            // 
            // nmudSize
            // 
            this.nmudSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nmudSize.Location = new System.Drawing.Point(372, 63);
            this.nmudSize.Margin = new System.Windows.Forms.Padding(4);
            this.nmudSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmudSize.Name = "nmudSize";
            this.nmudSize.Size = new System.Drawing.Size(75, 38);
            this.nmudSize.TabIndex = 0;
            this.nmudSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmudSize.ValueChanged += new System.EventHandler(this.nmudSize_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnChangeColor);
            this.panel1.Controls.Add(this.pctboxTest);
            this.panel1.Controls.Add(this.nmudColorB);
            this.panel1.Controls.Add(this.nmudColorG);
            this.panel1.Controls.Add(this.nmudColorR);
            this.panel1.Controls.Add(this.cmbParams);
            this.panel1.Controls.Add(this.cmbBlockType);
            this.panel1.Controls.Add(this.nmudSize);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 566);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(329, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 33);
            this.label5.TabIndex = 16;
            this.label5.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(174, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 33);
            this.label4.TabIndex = 15;
            this.label4.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(26, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "Изменение цветов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 33);
            this.label2.TabIndex = 13;
            this.label2.Text = "Изменение размеров:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(37, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "R";
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangeColor.Location = new System.Drawing.Point(80, 278);
            this.btnChangeColor.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(297, 32);
            this.btnChangeColor.TabIndex = 11;
            this.btnChangeColor.Text = "Изменить цвет";
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // pctboxTest
            // 
            this.pctboxTest.BackColor = System.Drawing.Color.White;
            this.pctboxTest.Location = new System.Drawing.Point(14, 339);
            this.pctboxTest.Margin = new System.Windows.Forms.Padding(4);
            this.pctboxTest.Name = "pctboxTest";
            this.pctboxTest.Size = new System.Drawing.Size(431, 210);
            this.pctboxTest.TabIndex = 10;
            this.pctboxTest.TabStop = false;
            // 
            // nmudColorB
            // 
            this.nmudColorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nmudColorB.Location = new System.Drawing.Point(372, 215);
            this.nmudColorB.Margin = new System.Windows.Forms.Padding(4);
            this.nmudColorB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmudColorB.Name = "nmudColorB";
            this.nmudColorB.Size = new System.Drawing.Size(75, 38);
            this.nmudColorB.TabIndex = 9;
            this.nmudColorB.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmudColorB.ValueChanged += new System.EventHandler(this.nmudColorB_ValueChanged);
            // 
            // nmudColorG
            // 
            this.nmudColorG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nmudColorG.Location = new System.Drawing.Point(218, 215);
            this.nmudColorG.Margin = new System.Windows.Forms.Padding(4);
            this.nmudColorG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmudColorG.Name = "nmudColorG";
            this.nmudColorG.Size = new System.Drawing.Size(75, 38);
            this.nmudColorG.TabIndex = 8;
            this.nmudColorG.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmudColorG.ValueChanged += new System.EventHandler(this.nmudColorG_ValueChanged);
            // 
            // nmudColorR
            // 
            this.nmudColorR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nmudColorR.Location = new System.Drawing.Point(80, 215);
            this.nmudColorR.Margin = new System.Windows.Forms.Padding(4);
            this.nmudColorR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmudColorR.Name = "nmudColorR";
            this.nmudColorR.Size = new System.Drawing.Size(75, 38);
            this.nmudColorR.TabIndex = 7;
            this.nmudColorR.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmudColorR.ValueChanged += new System.EventHandler(this.nmudColorR_ValueChanged);
            // 
            // cmbParams
            // 
            this.cmbParams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbParams.FormattingEnabled = true;
            this.cmbParams.Items.AddRange(new object[] {
            "Ширина блока",
            "Высота блока",
            "Расстояние по ширине",
            "Расстояние по высоте"});
            this.cmbParams.Location = new System.Drawing.Point(14, 62);
            this.cmbParams.Margin = new System.Windows.Forms.Padding(4);
            this.cmbParams.Name = "cmbParams";
            this.cmbParams.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbParams.Size = new System.Drawing.Size(341, 39);
            this.cmbParams.TabIndex = 6;
            this.cmbParams.SelectedIndexChanged += new System.EventHandler(this.cmbParams_SelectedIndexChanged);
            // 
            // cmbBlockType
            // 
            this.cmbBlockType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbBlockType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbBlockType.FormattingEnabled = true;
            this.cmbBlockType.Items.AddRange(new object[] {
            "Процесс",
            "Ввод/вывод",
            "Условие",
            "Цикл for",
            "Цикл while",
            "Терминатор"});
            this.cmbBlockType.Location = new System.Drawing.Point(18, 154);
            this.cmbBlockType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBlockType.Name = "cmbBlockType";
            this.cmbBlockType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBlockType.Size = new System.Drawing.Size(429, 39);
            this.cmbBlockType.TabIndex = 0;
            this.cmbBlockType.SelectedIndexChanged += new System.EventHandler(this.cmbBlockType_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(16, 589);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(467, 41);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сбросить настройки";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(500, 642);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(261, 235);
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmudSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudColorR)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.NumericUpDown nmudSize;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.ComboBox cmbBlockType;
		private System.Windows.Forms.ComboBox cmbParams;
		private System.Windows.Forms.NumericUpDown nmudColorB;
		private System.Windows.Forms.NumericUpDown nmudColorG;
		private System.Windows.Forms.NumericUpDown nmudColorR;
		private System.Windows.Forms.PictureBox pctboxTest;
		private System.Windows.Forms.Button btnChangeColor;
		private System.Windows.Forms.ColorDialog clrd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}