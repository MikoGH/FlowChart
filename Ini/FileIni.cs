using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    public class FileIni
    {
		Dictionary<string, string> dct;

		public FileIni()
		{
			Read();
		}

		public void Create()
		{
			dct = new Dictionary<string, string>()
			{
				{ "xSizeShape" , "200" },
				{ "ySizeShape" , "80" },
				{ "xDistance" , "50" },
				{ "yDistance" , "50" },
				{ "colorProcess" , "180,230,250" },
				{ "colorData" , "120,230,150" },
				{ "colorDecision" , "240,250,130" },
				{ "colorDecisionLoop" , "250,180,130" },
				{ "colorPreparation" , "250,130,130" },
				{ "colorTerminator" , "211,211,211" }
			};
			Write();
		}

		public Dictionary<string, string> Read()
			// чтение с ini файла
		{
			if (!File.Exists("settings.ini"))
			{
				Create();
			}
			string ini = File.ReadAllText("settings.ini");
			dct = new Dictionary<string, string>();
			foreach (string item in ini.Split('\n'))
			{
				if (item.Contains('='))
					dct.Add(item.Split('=')[0], item.Split('=')[1]);
			}
			return dct;
		}

		public void Write()
			// запись в ini файл
		{
			string data = "";
			foreach (string key in dct.Keys)
			{
				data += $"{key}={dct[key]}\n";
			}
			File.WriteAllText("settings.ini", data);
		}

		public string this[string key]
		{
			get => dct[key];
			set => dct[key] = value;
		}
	}
}
