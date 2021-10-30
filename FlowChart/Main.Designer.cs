
namespace FlowChart
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.btnCreateBD = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.txtboxName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 8);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(631, 570);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// btnCreateBD
			// 
			this.btnCreateBD.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCreateBD.Location = new System.Drawing.Point(941, 12);
			this.btnCreateBD.Name = "btnCreateBD";
			this.btnCreateBD.Size = new System.Drawing.Size(174, 35);
			this.btnCreateBD.TabIndex = 1;
			this.btnCreateBD.Text = "Create";
			this.btnCreateBD.UseVisualStyleBackColor = true;
			this.btnCreateBD.Click += new System.EventHandler(this.btnCreateBD_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.pictureBox);
			this.panel1.Location = new System.Drawing.Point(20, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(915, 801);
			this.panel1.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSave.Location = new System.Drawing.Point(941, 53);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(174, 35);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save Image";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtboxName
			// 
			this.txtboxName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtboxName.Location = new System.Drawing.Point(941, 94);
			this.txtboxName.Name = "txtboxName";
			this.txtboxName.Size = new System.Drawing.Size(174, 24);
			this.txtboxName.TabIndex = 4;
			this.txtboxName.Text = "FlowChart1";
			this.txtboxName.TextChanged += new System.EventHandler(this.txtboxName_TextChanged);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1127, 825);
			this.Controls.Add(this.txtboxName);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCreateBD);
			this.Controls.Add(this.panel1);
			this.Name = "FormMain";
			this.Text = "FlowChart";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button btnCreateBD;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtboxName;
	}
}

