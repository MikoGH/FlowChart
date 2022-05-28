
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCreateBD = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnDownload = new System.Windows.Forms.Button();
			this.rtxtBoxCode = new System.Windows.Forms.RichTextBox();
			this.buttonSettings = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.panelPicture.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(3, 3);
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
			this.panelPicture.Size = new System.Drawing.Size(680, 634);
			this.panelPicture.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnSave.Location = new System.Drawing.Point(9, 589);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(283, 35);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Сохранить картинку";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCreateBD
			// 
			this.btnCreateBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateBD.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCreateBD.Location = new System.Drawing.Point(9, 512);
			this.btnCreateBD.Name = "btnCreateBD";
			this.btnCreateBD.Size = new System.Drawing.Size(283, 71);
			this.btnCreateBD.TabIndex = 2;
			this.btnCreateBD.Text = "Визуализировать";
			this.btnCreateBD.UseVisualStyleBackColor = true;
			this.btnCreateBD.Click += new System.EventHandler(this.btnCreateBD_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoScroll = true;
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
			this.panel2.Controls.Add(this.buttonSettings);
			this.panel2.Controls.Add(this.btnDownload);
			this.panel2.Controls.Add(this.rtxtBoxCode);
			this.panel2.Controls.Add(this.btnCreateBD);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Location = new System.Drawing.Point(698, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(299, 634);
			this.panel2.TabIndex = 6;
			// 
			// btnDownload
			// 
			this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDownload.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnDownload.Location = new System.Drawing.Point(9, 4);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(284, 32);
			this.btnDownload.TabIndex = 1;
			this.btnDownload.Text = "Загрузить файл";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// rtxtBoxCode
			// 
			this.rtxtBoxCode.AcceptsTab = true;
			this.rtxtBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtxtBoxCode.AutoWordSelection = true;
			this.rtxtBoxCode.Location = new System.Drawing.Point(9, 41);
			this.rtxtBoxCode.Margin = new System.Windows.Forms.Padding(2);
			this.rtxtBoxCode.MinimumSize = new System.Drawing.Size(100, 200);
			this.rtxtBoxCode.Name = "rtxtBoxCode";
			this.rtxtBoxCode.Size = new System.Drawing.Size(284, 425);
			this.rtxtBoxCode.TabIndex = 0;
			this.rtxtBoxCode.TabStop = false;
			this.rtxtBoxCode.Text = "";
			this.rtxtBoxCode.TextChanged += new System.EventHandler(this.rtxtBoxCode_TextChanged);
			// 
			// buttonSettings
			// 
			this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSettings.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonSettings.Location = new System.Drawing.Point(9, 471);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(283, 35);
			this.buttonSettings.TabIndex = 4;
			this.buttonSettings.Text = "Настройки";
			this.buttonSettings.UseVisualStyleBackColor = true;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
			this.ClientSize = new System.Drawing.Size(1007, 659);
			this.Controls.Add(this.panelPicture);
			this.Controls.Add(this.panel2);
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FlowChart";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.panelPicture.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel panelPicture;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCreateBD;
		private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtxtBoxCode;
        private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.Button buttonSettings;
	}
}

