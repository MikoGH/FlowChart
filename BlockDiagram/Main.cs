using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
	public partial class FormMain : Form
	{
        Bitmap bitmap;
        string textNameBD = "";

        public FormMain()
            // инициализация формы
		{
			InitializeComponent();
		}

		private void btnCreateBD_Click(object sender, EventArgs e)
            // создание блок-схемы
		{
            // создание пустого рисунка
            pictureBox.Width = 2000;
            pictureBox.Height = 2000;
            bitmap = new Bitmap(2000, 2000);
            Graphics graphic = Graphics.FromImage(bitmap);
            // создание и отрисовка элементов блок-схемы

            Process process1 = new Process("123abc");
            process1.SetPosition(200, 100);
            process1.DrawShape(graphic);
            process1.DrawText(graphic);

            if (pictureBox.Image != null) pictureBox.Image.Dispose();
			pictureBox.Image = bitmap;

		}

		private void btnSave_Click(object sender, EventArgs e)
            // сохранение блок-схемы
		{
			if (textNameBD != "")
			{
                bitmap.Save(textNameBD + ".jpeg");
                MessageBox.Show(
                    "Блок-схема успешно сохранена",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
			else
			{
                MessageBox.Show(
                    "Введите название блок-схемы",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

		private void txtboxName_TextChanged(object sender, EventArgs e)
            // изменение названия блок-схемы
		{
            textNameBD = txtboxName.Text;
        }
	}
}
