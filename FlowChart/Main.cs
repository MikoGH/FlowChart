using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shapes;

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
            List<IBlock> blocks = new List<IBlock> { };

            // пока нет алгоритма преобразования кода в список объектов, так что объекты в функции создаются вручную
            blocks = Module.CreateBlocks(blocks);

            blocks[0].SetPositionY(0);
            blocks[0].SetPositionX(blocks[1].xDistance);
            for (int i = 1; i < blocks.Count; i++) // временно
			{
				blocks[i].SetPositionX(blocks[1].xDistance);
				blocks[i].SetPositionY(blocks[1].ySizeShape + blocks[1].yDistance);
				//blocks[i].SetPositionY(i * (blocks[1].ySizeShape + blocks[1].yDistance));
				//blocks[i].SetPositionY(blocks[1].yDistance);
			}

			// установка позиций блоков по X
			Module.SetPositionsX(blocks);
            // установка позиций блоков по Y
            Module.SetPositionsY(blocks);

			// создание пустого рисунка
			int pictureWidth = Module.GetPictureSizeX(blocks);
            int pictureHeight = Module.GetPictureSizeY(blocks);
            pictureBox.Width = pictureWidth;
            pictureBox.Height = pictureHeight;
            bitmap = new Bitmap(pictureWidth, pictureHeight);
            Graphics graphic = Graphics.FromImage(bitmap);

            // отрисовка элементов блок-схемы
            for (int i = 0; i<blocks.Count; i++)
			{
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
