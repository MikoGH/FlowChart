
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
			this.cmbParams = new System.Windows.Forms.ComboBox();
			this.cmbBlockType = new System.Windows.Forms.ComboBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.nmudColorR = new System.Windows.Forms.NumericUpDown();
			this.nmudColorG = new System.Windows.Forms.NumericUpDown();
			this.nmudColorB = new System.Windows.Forms.NumericUpDown();
			this.pctboxTest = new System.Windows.Forms.PictureBox();
			this.clrd = new System.Windows.Forms.ColorDialog();
			this.btnChangeColor = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nmudSize)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmudColorR)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmudColorG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmudColorB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pctboxTest)).BeginInit();
			this.SuspendLayout();
			// 
			// nmudSize
			// 
			this.nmudSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nmudSize.Location = new System.Drawing.Point(279, 51);
			this.nmudSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.nmudSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nmudSize.Name = "nmudSize";
			this.nmudSize.Size = new System.Drawing.Size(56, 32);
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
			this.panel1.Controls.Add(this.btnChangeColor);
			this.panel1.Controls.Add(this.pctboxTest);
			this.panel1.Controls.Add(this.nmudColorB);
			this.panel1.Controls.Add(this.nmudColorG);
			this.panel1.Controls.Add(this.nmudColorR);
			this.panel1.Controls.Add(this.cmbParams);
			this.panel1.Controls.Add(this.cmbBlockType);
			this.panel1.Controls.Add(this.nmudSize);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(350, 520);
			this.panel1.TabIndex = 1;
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
			this.cmbParams.Location = new System.Drawing.Point(12, 50);
			this.cmbParams.Name = "cmbParams";
			this.cmbParams.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbParams.Size = new System.Drawing.Size(257, 33);
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
			this.cmbBlockType.Location = new System.Drawing.Point(12, 161);
			this.cmbBlockType.Name = "cmbBlockType";
			this.cmbBlockType.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmbBlockType.Size = new System.Drawing.Size(323, 33);
			this.cmbBlockType.TabIndex = 0;
			this.cmbBlockType.SelectedIndexChanged += new System.EventHandler(this.cmbBlockType_SelectedIndexChanged);
			// 
			// btnReset
			// 
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnReset.Location = new System.Drawing.Point(12, 538);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(350, 33);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "Сбросить настройки";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// nmudColorR
			// 
			this.nmudColorR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nmudColorR.Location = new System.Drawing.Point(50, 200);
			this.nmudColorR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nmudColorR.Name = "nmudColorR";
			this.nmudColorR.Size = new System.Drawing.Size(56, 32);
			this.nmudColorR.TabIndex = 7;
			this.nmudColorR.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// nmudColorG
			// 
			this.nmudColorG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nmudColorG.Location = new System.Drawing.Point(50, 238);
			this.nmudColorG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nmudColorG.Name = "nmudColorG";
			this.nmudColorG.Size = new System.Drawing.Size(56, 32);
			this.nmudColorG.TabIndex = 8;
			this.nmudColorG.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// nmudColorB
			// 
			this.nmudColorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.nmudColorB.Location = new System.Drawing.Point(50, 276);
			this.nmudColorB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nmudColorB.Name = "nmudColorB";
			this.nmudColorB.Size = new System.Drawing.Size(56, 32);
			this.nmudColorB.TabIndex = 9;
			this.nmudColorB.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// pctboxTest
			// 
			this.pctboxTest.BackColor = System.Drawing.Color.White;
			this.pctboxTest.Location = new System.Drawing.Point(12, 336);
			this.pctboxTest.Name = "pctboxTest";
			this.pctboxTest.Size = new System.Drawing.Size(323, 171);
			this.pctboxTest.TabIndex = 10;
			this.pctboxTest.TabStop = false;
			// 
			// btnChangeColor
			// 
			this.btnChangeColor.Location = new System.Drawing.Point(112, 200);
			this.btnChangeColor.Name = "btnChangeColor";
			this.btnChangeColor.Size = new System.Drawing.Size(223, 26);
			this.btnChangeColor.TabIndex = 11;
			this.btnChangeColor.Text = "Изменить цвет";
			this.btnChangeColor.UseVisualStyleBackColor = true;
			this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
			this.ClientSize = new System.Drawing.Size(375, 583);
			this.Controls.Add(this.btnReset);
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
			((System.ComponentModel.ISupportInitialize)(this.nmudSize)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nmudColorR)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmudColorG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmudColorB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pctboxTest)).EndInit();
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
	}
}