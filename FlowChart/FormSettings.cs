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

namespace FlowChart
{
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			InitializeComponent();
		}

		public void FormSettings_Load(object sender, EventArgs e)
		{
			Dictionary<string, int> ini = ReadIni();
			nmudXSize.Value = ini["xSizeShape"];
		}

		#region Чтение и запись в ini файл
		public Dictionary<string,int> ReadIni()
		{
			string ini = File.ReadAllText("settings.ini");
			Dictionary<string, int> dct = new Dictionary<string, int>();
			foreach (string item in ini.Split('\n'))
			{
				if (item.Contains('='))
					dct.Add(item.Split('=')[0], int.Parse(item.Split('=')[1]));
			}
			return dct;
		}

		public void WriteIni(Dictionary<string, int> dct)
		{
			string data = "";
			foreach (string key in dct.Keys)
			{
				data += $"{key}={dct[key]}\n";
			}
			File.WriteAllText("settings.ini", data);
		}
		#endregion

		private void nmudXSize_ValueChanged(object sender, EventArgs e)
		// заменяет значение для xSizeShape в ini файле
		{
			Dictionary<string, int> ini = ReadIni();
			ini["xSizeShape"] = (int)nmudXSize.Value;
			WriteIni(ini);
		}
	}
}
