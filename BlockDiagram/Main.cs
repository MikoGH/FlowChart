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
        Bitmap targetBitmap;
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
            targetBitmap = new Bitmap(2000, 2000);
            // создание и отрисовка элементов блок-схемы
            using (Graphics graphic = Graphics.FromImage(targetBitmap))
            {
                Process process1 = new Process("123abc");
                process1.SetPosition(200, 100);
                process1.DrawShape(graphic);
                process1.DrawText(graphic);
            }

            if (pictureBox.Image != null) pictureBox.Image.Dispose();
			pictureBox.Image = targetBitmap;

		}

		private void btnSave_Click(object sender, EventArgs e)
            // сохранение блок-схемы
		{
			if (textNameBD != "")
			{
                targetBitmap.Save(textNameBD + ".jpeg");
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
