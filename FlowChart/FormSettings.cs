using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shapes;
using Ini;
using Modules;

namespace FlowChart
{
	public partial class FormSettings : Form
	{
		string changedSizeParam = null;
		string changedColourParam = null;
		string blockType = null;

		public FormSettings()
		{
			InitializeComponent();
		}

		public void FormSettings_Load(object sender, EventArgs e)
		{
		}

		#region Изменение размеров
		private void cmbParams_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbParams.SelectedItem.ToString() == "Ширина блока")
			{
				changedSizeParam = "xSizeShape";
			}
			else if (this.cmbParams.SelectedItem.ToString() == "Высота блока")
			{
				changedSizeParam = "ySizeShape";
			}
			else if (this.cmbParams.SelectedItem.ToString() == "Расстояние по ширине")
			{
				changedSizeParam = "xDistance";
			}
			else if (this.cmbParams.SelectedItem.ToString() == "Расстояние по высоте")
			{
				changedSizeParam = "yDistance";
			}

			FileIni ini = new FileIni();
			nmudSize.Value = int.Parse(ini[changedSizeParam]);
		}

		private void nmudSize_ValueChanged(object sender, EventArgs e)
		// заменяет значение выбранного параметра в ini файле
		{
			if (changedSizeParam == null)
				return; // если параметр не выбран
			FileIni ini = new FileIni();
			ini[changedSizeParam] = nmudSize.Value.ToString();
			ini.Write();
			DrawTest();
		}
		#endregion

		#region Изменение цветов
		private void cmbBlockType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cmbBlockType.SelectedItem.ToString() == "Процесс")
			{
				changedColourParam = "colorProcess";
			}
			else if (this.cmbBlockType.SelectedItem.ToString() == "Ввод/вывод")
			{
				changedColourParam = "colorData";
			}
			else if (this.cmbBlockType.SelectedItem.ToString() == "Условие")
			{
				changedColourParam = "colorDecision";
			}
			else if (this.cmbBlockType.SelectedItem.ToString() == "Цикл for")
			{
				changedColourParam = "colorDecisionLoop";
			}
			else if (this.cmbBlockType.SelectedItem.ToString() == "Цикл while")
			{
				changedColourParam = "colorPreparation";
			}
			else if (this.cmbBlockType.SelectedItem.ToString() == "Терминатор")
			{
				changedColourParam = "colorTerminator";
			}
			DrawTest();
		}

		private void btnChangeColor_Click(object sender, EventArgs e)
		{
			if (changedColourParam == null)
				return; // если параметр не выбран
			//clrd.ShowDialog();
			DialogResult colorResult = clrd.ShowDialog();
			FileIni ini = new FileIni();
			if (colorResult == DialogResult.OK)
            {
				//pctboxTest.BackColor = clrd.Color;
				string colour = null;
				string r = clrd.Color.R.ToString();
				string g = clrd.Color.G.ToString();
				string b = clrd.Color.B.ToString();
				colour = r + "," + g + "," + b;
				ini[changedColourParam] = colour;
				ini.Write();
				DrawTest();
			}
		}

		private void nmudColorR_ValueChanged(object sender, EventArgs e)
		{
			if (changedColourParam == null)
				return; // если параметр не выбран
			FileIni ini = new FileIni();
			string[] colour = ini[changedColourParam].Split(new char[] { ',' });
			ini[changedColourParam] = nmudColorR.Value.ToString() + ',' + colour[1] + ',' + colour[2];
			ini.Write();
			DrawTest();
		}

		private void nmudColorG_ValueChanged(object sender, EventArgs e)
		{
			if (changedColourParam == null)
				return; // если параметр не выбран
			FileIni ini = new FileIni();
			string[] colour = ini[changedColourParam].Split(new char[] { ',' });
			ini[changedColourParam] = colour[0] + ',' + nmudColorG.Value.ToString() + ',' + colour[2];
			ini.Write();
			DrawTest();
		}

		private void nmudColorB_ValueChanged(object sender, EventArgs e)
		{
			if (changedColourParam == null)
				return; // если параметр не выбран
			FileIni ini = new FileIni();
			string[] colour = ini[changedColourParam].Split(new char[] { ',' });
			ini[changedColourParam] = colour[0] + ',' + colour[1] + ',' + nmudColorB.Value.ToString();
			ini.Write();
			DrawTest();
		}
		#endregion

		#region Предпросмотр
		private void DrawTest()
		// рисует пример блока с изменёнными параметрами
		{
			// создание блока
			IBlock blockTest = new Process("");
			if (this.cmbBlockType.SelectedItem.ToString() == "Процесс")
				blockTest = new Process("");
			else if (this.cmbBlockType.SelectedItem.ToString() == "Ввод/вывод")
				blockTest = new Data("");
			else if (this.cmbBlockType.SelectedItem.ToString() == "Условие")
				blockTest = new Decision("");
			else if (this.cmbBlockType.SelectedItem.ToString() == "Цикл for")
				blockTest = new Preparation("");
			else if (this.cmbBlockType.SelectedItem.ToString() == "Цикл while")
				blockTest = new DecisionLoop("");
			else if (this.cmbBlockType.SelectedItem.ToString() == "Терминатор")
				blockTest = new Terminator("");

			// изменение координат блока на рисунке
			blockTest.SetPositionX(pctboxTest.Width / 2 - blockTest.xSizeShape / 2);
			blockTest.SetPositionY(pctboxTest.Height / 2 - blockTest.ySizeShape / 2);

			// создание рисунка
			Bitmap bitmap = new Bitmap(pctboxTest.Width, pctboxTest.Height);
			Graphics graphic = Graphics.FromImage(bitmap);

			// отрисовка блока
			blockTest.DrawShape(graphic);
			blockTest.DrawText(graphic);

			if (pctboxTest.Image != null) pctboxTest.Image.Dispose();
			pctboxTest.Image = bitmap;
		}
		#endregion

		#region Сброс настроек
		private void btnReset_Click(object sender, EventArgs e)
		// сбрасывает настройки на стандартные
		{
			FileIni ini = new FileIni();
			ini["xSizeShape"] = "200";
			ini["ySizeShape"] = "80";
			ini["xDistance"] = "50";
			ini["yDistance"] = "50";
			ini["colorProcess"] = "180,230,250";
			ini["colorData"] = "120,230,150";
			ini["colorDecision"] = "240,250,130";
			ini["colorDecisionLoop"] = "250,180,130";
			ini["colorPreparation"] = "250,130,130";
			ini["colorTerminator"] = "211,211,211";
			ini.Write();
			DrawTest();
		}
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
