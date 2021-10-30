using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
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

            List<IBlock> blocks = new List<IBlock> { };

            // тут будет алгоритм преобразования кода в список объектов 
            // пока нет алгоритма, так что объекты в функции создаются вручную
            blocks = ModuleCreate.CreateBlocks(blocks);

            // установка позиций блоков по X
            ModulePos.SetPositionsX(blocks);

            // отрисовка элементов блок-схемы
            for (int i = 0; i<blocks.Count; i++)
			{
                blocks[i].SetPosition(300, i*150);
                blocks[i].SetConnectorsPosition();
                blocks[i].DrawShape(graphic);
				blocks[i].DrawText(graphic);
                blocks[i].DrawConnectors(graphic);
            }
            
            if (pictureBox.Image != null) pictureBox.Image.Dispose();
			pictureBox.Image = bitmap;
		}

		private void btnSave_Click(object sender, EventArgs e)
        // сохранение блок-схемы
		{
			if (textNameBD != "")
			{
                bitmap.Save($@"..\..\..\Saved Diagrams\{textNameBD}.jpeg");
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
