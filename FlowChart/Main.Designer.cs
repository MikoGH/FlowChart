
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
			this.panelPicture = new System.Windows.Forms.Panel();
			this.txtboxName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCreateBD = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.panelPicture.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(17, 13);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(351, 222);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// panelPicture
			// 
			this.panelPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelPicture.AutoScroll = true;
			this.panelPicture.BackColor = System.Drawing.Color.White;
			this.panelPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelPicture.Controls.Add(this.pictureBox);
			this.panelPicture.Location = new System.Drawing.Point(12, 12);
			this.panelPicture.Name = "panelPicture";
			this.panelPicture.Size = new System.Drawing.Size(753, 634);
			this.panelPicture.TabIndex = 2;
			// 
			// txtboxName
			// 
			this.txtboxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtboxName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.txtboxName.Location = new System.Drawing.Point(9, 91);
			this.txtboxName.Name = "txtboxName";
			this.txtboxName.Size = new System.Drawing.Size(200, 24);
			this.txtboxName.TabIndex = 3;
			this.txtboxName.Text = "FlowChart1";
			this.txtboxName.TextChanged += new System.EventHandler(this.txtboxName_TextChanged);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnSave.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSave.Location = new System.Drawing.Point(9, 50);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(200, 35);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save Image";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCreateBD
			// 
			this.btnCreateBD.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCreateBD.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCreateBD.Location = new System.Drawing.Point(9, 9);
			this.btnCreateBD.Name = "btnCreateBD";
			this.btnCreateBD.Size = new System.Drawing.Size(200, 35);
			this.btnCreateBD.TabIndex = 1;
			this.btnCreateBD.Text = "Create";
			this.btnCreateBD.UseVisualStyleBackColor = true;
			this.btnCreateBD.Click += new System.EventHandler(this.btnCreateBD_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
			this.panel2.Controls.Add(this.btnCreateBD);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.txtboxName);
			this.panel2.Location = new System.Drawing.Point(781, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(216, 634);
			this.panel2.TabIndex = 6;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
			this.ClientSize = new System.Drawing.Size(1007, 659);
			this.Controls.Add(this.panelPicture);
			this.Controls.Add(this.panel2);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FlowChart";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.panelPicture.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel panelPicture;
		private System.Windows.Forms.TextBox txtboxName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCreateBD;
		private System.Windows.Forms.Panel panel2;
	}
}

