using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;
using System.Text.RegularExpressions;

namespace Modules
{
	public partial class Module
	{
		/// <summary>
		/// Заменяет текст в блоке цикл for.
		/// </summary>
		public static void SetTextPreparation(Shape block)
		{
			block.text = block.text.Replace("++", "+=1").Replace("--", "-=1").Trim();
			if (Regex.IsMatch(block.text, @"^[A-Za-z0-9_]+ *[A-Za-z0-9_]+ *= *[A-Za-z0-9_]+ *; *[A-Za-z0-9_]+ *[<>]=? *[A-Za-z0-9_]+ *; *[A-Za-z0-9_]+ *(\+=|-=) *[A-Za-z0-9_]+$"))
			{
				string[] splits = block.text.Split(';');
				string variable = splits[0].Split('=')[0].Trim();
				string from = splits[0].Split('=')[1].Trim();
				string include = Regex.Match(splits[1], @"(?<=[<>]).").Value == "=" ? "вкл." : "";
				string to = Regex.Split(splits[1], @"[<>]=?")[1].Trim();
				string sign = Regex.Match(splits[2], @".(?==)").Value == "-" ? "-" : "";
				string step = Regex.Split(splits[2], @"(\+=|\-=)")[2];
				block.text = $"для {variable}\nот {from} до {to} {include}\nс шагом {sign}{step}";
			}
		}

		/// <summary>
		/// Заменяет текст в блоке цикл while.
		/// </summary>
		public static void SetTextDecisionLoop(Shape block)
		{
			block.text = block.text.Replace("==", "=").Trim();
			if (block.text.Length != 0)
			{
				block.text = $"пока {block.text}";
			}
		}
		
		/// <summary>
		/// Заменяет текст в блоке условие.
		/// </summary>
		public static void SetTextDecision(Shape block)
		{
			block.text = block.text.Replace("==", "=").Trim();
			if (block.text.Length != 0)
			{
				block.text = $"{block.text} ?";
			}
		}

		/// <summary>
		/// Заменяет текст во всех блоках массива.
		/// </summary>
		public static void SetTextBlocks(List<IBlock> blocks)
		{
			foreach (IBlock block in blocks)
			{
				if (block is Preparation)
					SetTextPreparation((Shape)block);
				if (block is DecisionLoop)
					SetTextDecisionLoop((Shape)block);
				if (block is Decision | block is DecisionFull)
					SetTextDecision((Shape)block);
			}
		}
	}
}
