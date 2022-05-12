
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
            this.rtxtBoxCode = new System.Windows.Forms.RichTextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPicture.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(4, 4);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(468, 273);
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
            this.panelPicture.Location = new System.Drawing.Point(16, 15);
            this.panelPicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(1003, 780);
            this.panelPicture.TabIndex = 2;
            // 
            // txtboxName
            // 
            this.txtboxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtboxName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtboxName.Location = new System.Drawing.Point(67, 653);
            this.txtboxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtboxName.Name = "txtboxName";
            this.txtboxName.Size = new System.Drawing.Size(211, 28);
            this.txtboxName.TabIndex = 3;
            this.txtboxName.Text = "FlowChart1";
            this.txtboxName.TextChanged += new System.EventHandler(this.txtboxName_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(11, 700);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(267, 64);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateBD
            // 
            this.btnCreateBD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateBD.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateBD.Location = new System.Drawing.Point(12, 505);
            this.btnCreateBD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateBD.Name = "btnCreateBD";
            this.btnCreateBD.Size = new System.Drawing.Size(267, 118);
            this.btnCreateBD.TabIndex = 1;
            this.btnCreateBD.Text = "Create Diagram";
            this.btnCreateBD.UseVisualStyleBackColor = true;
            this.btnCreateBD.Click += new System.EventHandler(this.btnCreateBD_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.btnDownload);
            this.panel2.Controls.Add(this.nameLabel);
            this.panel2.Controls.Add(this.rtxtBoxCode);
            this.panel2.Controls.Add(this.btnCreateBD);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtboxName);
            this.panel2.Location = new System.Drawing.Point(1041, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 780);
            this.panel2.TabIndex = 6;
            // 
            // rtxtBoxCode
            // 
            this.rtxtBoxCode.Location = new System.Drawing.Point(12, 48);
            this.rtxtBoxCode.Name = "rtxtBoxCode";
            this.rtxtBoxCode.Size = new System.Drawing.Size(267, 428);
            this.rtxtBoxCode.TabIndex = 4;
            this.rtxtBoxCode.Text = "";
            this.rtxtBoxCode.TextChanged += new System.EventHandler(this.rtxtBoxCode_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.nameLabel.Location = new System.Drawing.Point(11, 660);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 17);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDownload.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDownload.Location = new System.Drawing.Point(12, 5);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(267, 36);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Download File";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1343, 811);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.RichTextBox rtxtBoxCode;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label nameLabel;
    }
}

