using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Shapes;
using Modules;

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
            // считывание текста кода с элемента  управления
            string code = rtxtBoxCode.Text;

            // создание массива блоков из кода
            List<IBlock> blocks = Module.CreateBlocks(code);
			blocks.Insert(0, new Terminator("Начало", true));
			blocks.Add(new Terminator("Конец", false));

			blocks[0].SetPositionY(0);
            blocks[0].SetPositionX(blocks[1].xDistance);
            for (int i = 1; i < blocks.Count; i++) // временно, но теперь уже навсегда
			{
				blocks[i].SetPositionX(blocks[1].xDistance);
				blocks[i].SetPositionY(blocks[1].ySizeShape + blocks[1].yDistance);
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
            //if (textNameBD != "")
            //{
            //             bitmap.Save($@"..\..\..\Saved Diagrams\{textNameBD}.jpeg");
            //             MessageBox.Show(
            //                 "Блок-схема успешно сохранена",
            //                 "Сообщение",
            //                 MessageBoxButtons.YesNo,
            //                 MessageBoxIcon.Information,
            //                 MessageBoxDefaultButton.Button1,
            //                 MessageBoxOptions.DefaultDesktopOnly);
            //         }
            //else
            //{
            //             MessageBox.Show(
            //                 "Введите название блок-схемы",
            //                 "Предупреждение",
            //                 MessageBoxButtons.YesNo,
            //                 MessageBoxIcon.Information,
            //                 MessageBoxDefaultButton.Button1,
            //                 MessageBoxOptions.DefaultDesktopOnly);
            //         }

            if (pictureBox.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "JPEG файлы|*.jpeg|PNG файлы|*.png|Все файлы|*.*";
                sfd.ShowHelp = true;

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox.Image.Save(sfd.FileName);
                        MessageBox.Show("Блок-схема успешно сохранена", "Сообщение", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Изображение пустое. Создайте блок-схему.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void txtboxName_TextChanged(object sender, EventArgs e)
        // изменение названия блок-схемы
        {
            textNameBD = txtboxName.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        // действие при нажатии на текст "Название" - пока ничего нет
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        // загрузка кода из файла
        {
            //string textNameFile = "code03";      // название файла - нужно изменить
            //string code = new StreamReader($@"..\..\..\Files\{textNameFile}.txt").ReadToEnd();
            //rtxtBoxCode.Text = code;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выбрать файл...";
            if (ofd.ShowDialog() == DialogResult.OK)
            { 
                if (Path.GetExtension(ofd.FileName) == ".txt" || Path.GetExtension(ofd.FileName) == ".cs")
                {
                    rtxtBoxCode.Text = File.ReadAllText(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Невозможно считать код из файла. Код считывается только из форматов txt и cs.", "Ошибка", MessageBoxButtons.OK);
                    //rtxtBoxCode.Text = "Невозможно считать код из файла. Код считывается только из форматов txt и cs.";
                }
            }
        }

        private void rtxtBoxCode_TextChanged(object sender, EventArgs e)
        // действие при изменении текста кода - пока ничего нет
        {
            
        }
    }
}
