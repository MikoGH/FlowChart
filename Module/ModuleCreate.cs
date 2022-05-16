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
using System.Text.RegularExpressions;

namespace Modules
{
	public partial class Module
	{
		#region Проверка типа
		/// <summary>
		/// Проверка, является ли начало текста кода циклом for.
		/// </summary>
		public static bool IsPreparation(string code)
		{
			if (code.StartsWith("for"))
				return true;
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода циклом while.
		/// </summary>
		public static bool IsDecisionLoop(string code)
		{
			if (code.StartsWith("while"))
				return true;
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода полным условием.
		/// </summary>
		public static bool IsDecisionFull(string code)
		{
			int indexBracketEnd = FindEndBracket(code, '{', '}');
			if (code.StartsWith("if"))
			{
				code = DeleteSpaces(code.Substring(indexBracketEnd + 1));
				if (code.StartsWith("else"))
				{
					code = DeleteSpaces(code.Substring(4,  FindEndBracket(code, '{', '}')-4));
					if (IsBlock(code))
						return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода неполным условием.
		/// </summary>
		public static bool IsDecision(string code)
		{
			int indexBracketEnd = FindEndBracket(code, '{', '}');
			if (code.StartsWith("if"))
			{
				code = DeleteSpaces(code.Substring(indexBracketEnd + 1));
				if (code.StartsWith("else"))
				{
					code = DeleteSpaces(code.Substring(4, FindEndBracket(code, '{', '}') - 4));
					if (IsBlock(code))
						return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода вводом/выводом данных.
		/// </summary>
		public static bool IsData(string code)
		{
			if (code.Contains("="))
				code = code.Substring(code.IndexOf("=")+1);
			code = DeleteSpaces(code);
			if ((code.StartsWith("Console.WriteLine") ||
				code.StartsWith("Console.Write") ||
				code.StartsWith("Console.ReadLine") ||
				code.StartsWith("Console.Read"))
				&& IsProcess(code))
				return true;
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода процессом.
		/// </summary>
		public static bool IsProcess(string code)
		{
			int t = 0;
			for (int i = 0; i < code.Count(x => x == ';'); i++)
			{
				t = code.IndexOf(';', t+1);
				if (code.Substring(0, t).Count(x => x == '"') % 2 == 0)
					return true;
			}
			return false;
		}

		/// <summary>
		/// Проверка, является ли начало текста кода каким-либо блоком.
		/// </summary>
		public static bool IsBlock(string code)
		{
			if (IsPreparation(code)) return true;
			if (IsDecisionLoop(code)) return true;
			if (IsDecisionFull(code)) return true;
			if (IsDecision(code)) return true;
			if (IsData(code)) return true;
			if (IsProcess(code)) return true;
			return false;
		}
		#endregion

		#region Работа со скобками и пробелами
		/// <summary>
		/// Возвращает индекс закрывающей скобки в тексте кода.
		/// </summary>
		public static int FindEndBracket(string code, char bracketStart, char bracketEnd)
		{
			// ! при поиске }) сделать проверки на то, что }) не относятся к блоку 

			int index = 0;
			int countBracket = 0;
			// поиск индекса соответствующей закрывающей скобки.
			// Увеличивает счётчик, если найдена открывающая скобка, и уменьшает, если найдена закрывающая. 
			// Если найдена закрывающая скобка и счётчик равен 1, возвращает индекс.
			foreach (char smb in code)
			{
				if (smb == bracketStart)
					countBracket++;
				else if (smb == bracketEnd)
				{
					if (countBracket == 1)
						return index;
					countBracket--;
				}
				index++;
			}
			// если не найдено
			return 0;
		}

		/// <summary>
		/// Возвращает текст кода в скобках.
		/// </summary>
		public static string GetTextInBrackets(string code, char bracketStart, char bracketEnd)
		{
			// индексы начала и конца подстроки
			if (code.Contains(bracketStart) && code.Contains(bracketEnd))
			{
				int start = code.IndexOf(bracketStart) + 1;
				int end = FindEndBracket(code, bracketStart, bracketEnd) - start;
				return code.Substring(start, end);
			}
			return "";
		}

		/// <summary>
		/// Удаляет все пробелы и переносы строки из начала кода.
		/// </summary>
		public static string DeleteSpaces(string code)
		{
			if (code.Length != 0)
			{
				while (new char[] { ' ', '\n', '\t', '\r' }.Contains(code[0]))
				{
					code = code.Substring(1);
					if (code.Length == 0)
						break;
				}
			}
			return code;
		}
		#endregion

		#region Создание блока
		/// <summary>
		/// Создание блока цикл for
		/// </summary>
		public static void CreatePreparation(ref List<IBlock> blocks, ref string code)
		{
			code = DeleteSpaces(code);
			// создание объекта типа цикл for
			Preparation preparation = new Preparation(GetTextInBrackets(code, '(', ')'));
			blocks.Add(preparation);

			// срез строки. Обрезание начала кода, содержащего последний блок
			code = code.Substring(FindEndBracket(code, '(', ')') + 1);
			code = DeleteSpaces(code);

			// создание коллекции из объектов в теле цикла for
			string codeIn = code.Substring(0, FindEndBracket(code, '{', '}'));
			codeIn = codeIn.Substring(codeIn.IndexOf("{") + 1);
			codeIn = DeleteSpaces(codeIn);
			List<IBlock> blocksIn = CreateBlocks(codeIn);
			preparation.blocksBody = blocksIn;
			blocks = blocks.Concat(blocksIn).ToList();
			// для всех блоков в теле цикла добавить в массив внешних циклов текущий цикл for
			foreach (IBlock block in blocksIn)
				block.blocksPreparation.Insert(0, preparation);

			// срез строки. Обрезание начала кода, содержащего тело последнего блока
			code = code.Substring(FindEndBracket(code, '{', '}') + 1);
			code = DeleteSpaces(code);
		}

		/// <summary>
		/// Создание блока цикл while
		/// </summary>
		public static void CreateDecisionLoop(ref List<IBlock> blocks, ref string code)
		{
			code = DeleteSpaces(code);
			// создание объекта типа цикл while
			DecisionLoop decisionLoop = new DecisionLoop(GetTextInBrackets(code, '(', ')'));
			blocks.Add(decisionLoop);

			// срез строки. Обрезание начала кода, содержащего последний блок
			code = code.Substring(FindEndBracket(code, '(', ')') + 1);
			code = DeleteSpaces(code);

			// создание коллекции из объектов в теле цикла while
			string codeIn = code.Substring(0, FindEndBracket(code, '{', '}'));
			codeIn = codeIn.Substring(codeIn.IndexOf("{") + 1);
			codeIn = DeleteSpaces(codeIn);
			List<IBlock> blocksIn = CreateBlocks(codeIn);
			decisionLoop.blocksBody = blocksIn;
			blocks = blocks.Concat(blocksIn).ToList();
			// для всех блоков в теле цикла добавить в массив внешних циклов текущий цикл while
			foreach (IBlock block in blocksIn)
				block.blocksDecisionLoop.Insert(0, decisionLoop);

			// срез строки. Обрезание начала кода, содержащего тело последнего блока
			code = code.Substring(FindEndBracket(code, '{', '}') + 1);
			code = DeleteSpaces(code);
		}
		
		/// <summary>
		/// Создание блока неполное условие
		/// </summary>
		public static void CreateDecision(ref List<IBlock> blocks, ref string code)
		{
			code = DeleteSpaces(code);
			// создание объекта типа неполное условие
			Decision decision = new Decision(GetTextInBrackets(code, '(', ')'));
			blocks.Add(decision);

			// срез строки. Обрезание начала кода, содержащего последний блок
			code = code.Substring(FindEndBracket(code, '(', ')') + 1);
			code = DeleteSpaces(code);

			// создание коллекции из объектов в теле неполного условия
			string codeIn = code.Substring(0, FindEndBracket(code, '{', '}'));
			codeIn = codeIn.Substring(codeIn.IndexOf("{") + 1);
			codeIn = DeleteSpaces(codeIn);
			List<IBlock> blocksIn = CreateBlocks(codeIn);
			decision.blocksBody = blocksIn;
			blocks = blocks.Concat(blocksIn).ToList();
			// для всех блоков в теле добавить в массив внешних условий текущее неполное условие
			foreach (IBlock block in blocksIn)
				block.blocksDecision.Insert(0, decision);

			// срез строки. Обрезание начала кода, содержащего тело последнего блока
			code = code.Substring(FindEndBracket(code, '{', '}') + 1);
			code = DeleteSpaces(code);
		}

		/// <summary>
		/// Создание блока полное условие
		/// </summary>
		public static void CreateDecisionFull(ref List<IBlock> blocks, ref string code)
		{
			code = DeleteSpaces(code);
			// создание объекта типа полное условие
			DecisionFull decisionFull = new DecisionFull(GetTextInBrackets(code, '(', ')'));
			blocks.Add(decisionFull);

			// срез строки. Обрезание начала кода, содержащего последний блок
			code = code.Substring(FindEndBracket(code, '(', ')') + 1);
			code = DeleteSpaces(code);

			// создание коллекции из объектов в теле если полного условия
			string codeIn = code.Substring(0, FindEndBracket(code, '{', '}'));
			codeIn = codeIn.Substring(codeIn.IndexOf("{") + 1);
			codeIn = DeleteSpaces(codeIn);
			List<IBlock> blocksIn = CreateBlocks(codeIn);
			decisionFull.blocksBody = blocksIn;
			blocks = blocks.Concat(blocksIn).ToList();
			// для всех блоков в теле добавить в массив внешних условий текущее полное условие
			foreach (IBlock block in blocksIn)
				block.blocksDecisionFullThen.Insert(0, decisionFull);

			// срез строки. Обрезание начала кода, содержащего тело последнего блока
			code = code.Substring(FindEndBracket(code, '{', '}') + 1);
			code = DeleteSpaces(code);

			// создание коллекции из объектов в теле иначе полного условия
			codeIn = code.Substring(code.IndexOf("{"));
			codeIn = codeIn.Substring(0, FindEndBracket(codeIn, '{', '}'));
			codeIn = codeIn.Substring(codeIn.IndexOf("{") + 1);
			codeIn = DeleteSpaces(codeIn);
			blocksIn = CreateBlocks(codeIn);
			decisionFull.blocksBodyElse = blocksIn;
			blocks = blocks.Concat(blocksIn).ToList();
			// для всех блоков в теле добавить в массив внешних условий текущее полное условие
			foreach (IBlock block in blocksIn)
				block.blocksDecisionFullElse.Insert(0, decisionFull);

			// срез строки. Обрезание начала кода, содержащего тело последнего блока
			code = code.Substring(FindEndBracket(code, '{', '}') + 1);
			code = DeleteSpaces(code);
		}
		
		/// <summary>
		/// Создание блока ввод/вывод данных
		/// </summary>
		public static void CreateData(ref List<IBlock> blocks, ref string code)
		{
			// Если в строке есть знак присвоения, разделить ввод на два блока:
			// вывод текста на экран и ввод в переменную
			if (code.Substring(0,code.IndexOf("Console.")).Contains("=")) // ! сделать проверку, что "=" до операции Console. ...
			{
				code = DeleteSpaces(code);
				// Создание объектов типа ввод/вывод данных
				string textInData = GetTextInBrackets(code.Substring(code.IndexOf("=")), '(', ')');
				if (textInData != "")
				{
					Data dataWrite = new Data(textInData);
					blocks.Add(dataWrite);
				}
				code = DeleteSpaces(code);
				Data dataRead = new Data(code.Substring(0, code.IndexOf("=")));
				blocks.Add(dataRead);
			}
			else
			{
				// Создание объектов типа ввод/вывод данных
				Data data = new Data(GetTextInBrackets(code, '(', ')'));
				blocks.Add(data);
			}

			// срез строки. Обрезание начала кода, содержащего последний блок
			int posEnd = 0;
			for (int i = 0; i < code.Count(x => x == ';'); i++)
			{
				posEnd = code.IndexOf(';', posEnd + 1);
				if (code.Substring(0, posEnd).Count(x => x == '"') % 2 == 0)
					break;
			}
			code = code.Substring(posEnd + 1);
			code = DeleteSpaces(code);
		}

		/// <summary>
		/// Создание блока процесс
		/// </summary>
		public static void CreateProcess(ref List<IBlock> blocks, ref string code)
		{
			code = DeleteSpaces(code);
			int posEnd = 0;
			for (int i = 0; i < code.Count(x => x == ';'); i++)
			{
				posEnd = code.IndexOf(';', posEnd + 1);
				if (code.Substring(0, posEnd).Count(x => x == '"') % 2 == 0)
					break;
			}
			Process process = new Process(code.Substring(0, posEnd));
			blocks.Add(process);

			// срез строки. Обрезание начала кода, содержащего последний блок
			code = code.Substring(posEnd + 1);
			code = DeleteSpaces(code);
		}
		#endregion

		#region Создание массива блоков
		public static List<IBlock> CreateBlocks(string code)
		{
			List<IBlock> blocks = new List<IBlock>();
			while (code!="")
			{
				if (IsPreparation(code)) // если цикл for
				{
					CreatePreparation(ref blocks, ref code);
				}
				else
				if (IsDecisionLoop(code)) // если цикл while
				{
					CreateDecisionLoop(ref blocks, ref code);
				}
				else
				if (IsDecision(code)) // если неполное условие
				{
					CreateDecision(ref blocks, ref code);
				}
				else
				if (IsDecisionFull(code)) // если полное условие
				{
					CreateDecisionFull(ref blocks, ref code);
				}
				else
				if (IsData(code)) // если ввод/вывод данных
				{
					CreateData(ref blocks, ref code);
				}
				else
				if (IsProcess(code)) // если процесс
				{
					CreateProcess(ref blocks, ref code);
				}
				else break;
			}

			SetTextBlocks(blocks);

			return blocks;
		}
		#endregion


		#region Временный метод
		public static List<IBlock> CreateBlocks(List<IBlock> blocks)
		{
			// тут будет алгоритм преобразования кода в список объектов 
			// пока что объекты создаются вручную

			// -4
			blocks.Add(new Terminator("Начало", true)); // 0 begin

			blocks.Add(new DecisionFull("123 > abc")); // 1 if

			blocks.Add(new DecisionFull("123 > 123")); // 2 then if
			blocks[2].blocksDecisionFullThen.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBody.Add(blocks[2]);

			blocks.Add(new Process("int a = 0")); // 3 then then
			blocks[3].blocksDecisionFullThen.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBody.Add(blocks[3]);
			blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			blocks.Add(new Process("int a = 1")); // 4 then else
			blocks[4].blocksDecisionFullThen.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBody.Add(blocks[4]);
			blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			blocks.Add(new Process("int a = 1")); // 5 else
			blocks[5].blocksDecisionFullElse.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBodyElse.Add(blocks[5]);

			blocks.Add(new Preparation("i = 0, i < n, i++")); // 6 else for
			blocks[6].blocksDecisionFullElse.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBodyElse.Add(blocks[6]);

			blocks.Add(new Process("int a = 2")); // 7 then else
			blocks[7].blocksDecisionFullElse.Add(blocks[1]);
			((DecisionFull)blocks[1]).blocksBodyElse.Add(blocks[7]);
			blocks[7].blocksPreparation.Add(blocks[6]);
			((Preparation)blocks[6]).blocksBody.Add(blocks[7]);

			blocks.Add(new Terminator("Конец", false)); // 8 end
			return blocks;

			//-3
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new DecisionFull("123 > abc")); // 1 if

			//blocks.Add(new DecisionFull("123 > 123")); // 2 then if
			//blocks[2].blocksDecisionFullThen.Add(blocks[1]);
			//((DecisionFull)blocks[1]).blocksBody.Add(blocks[2]);

			//blocks.Add(new Process("int a = 0")); // 3 then then
			//blocks[3].blocksDecisionFullThen.Add(blocks[1]);
			//((DecisionFull)blocks[1]).blocksBody.Add(blocks[3]);
			//blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			//blocks.Add(new Process("int a = 1")); // 4 then else
			//blocks[4].blocksDecisionFullThen.Add(blocks[1]);
			//((DecisionFull)blocks[1]).blocksBody.Add(blocks[4]);
			//blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			//blocks.Add(new Preparation("i = 0, i < n, i++")); // 5 else for
			//blocks[5].blocksDecisionFullElse.Add(blocks[1]);
			//((DecisionFull)blocks[1]).blocksBodyElse.Add(blocks[5]);

			//blocks.Add(new Process("int a = 2")); // 6 then else
			//blocks[6].blocksDecisionFullElse.Add(blocks[1]);
			//((DecisionFull)blocks[1]).blocksBodyElse.Add(blocks[6]);
			//blocks[6].blocksPreparation.Add(blocks[5]);
			//((Preparation)blocks[5]).blocksBody.Add(blocks[6]);

			//blocks.Add(new Terminator("Конец", false)); // 6 end
			//return blocks;

			//-2
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new Preparation(" ")); // 1

			//blocks.Add(new Process("int a = 0")); // 2
			//blocks[2].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[2]);

			//blocks.Add(new DecisionFull("123 > abc")); // 3 if

			//blocks.Add(new Process("int a = 0")); // 4 then
			//blocks[4].blocksDecisionFullThen.Add(blocks[3]);
			//((DecisionFull)blocks[3]).blocksBody.Add(blocks[4]);

			//blocks.Add(new Preparation("i = 0, i < n, i++")); // 5 else for
			//blocks[5].blocksDecisionFullElse.Add(blocks[3]);
			//((DecisionFull)blocks[3]).blocksBodyElse.Add(blocks[5]);

			//blocks.Add(new Process("int a = 1")); // 6 else then
			//blocks[6].blocksDecisionFullElse.Add(blocks[3]);
			//((DecisionFull)blocks[3]).blocksBodyElse.Add(blocks[6]);
			//blocks[6].blocksPreparation.Add(blocks[5]);
			//((Preparation)blocks[5]).blocksBody.Add(blocks[6]);

			//blocks.Add(new Terminator("Конец", false)); // 6 end
			//return blocks;

			// -1
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new Preparation("int a = 0")); // 1 for

			//blocks.Add(new DecisionFull("123 > abc")); // 2 for if
			//blocks[2].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[2]);

			//blocks.Add(new Process("int a = 0")); // 3 for then
			//blocks[3].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[3]);
			//blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			//blocks.Add(new Preparation("i = 0, i < n, i++")); // 4 for else for
			//blocks[4].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[4]);
			//blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			//blocks.Add(new Process("int a = 1")); // 5 for else then
			//blocks[5].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[5]);
			//blocks[5].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[5]);
			//blocks[5].blocksPreparation.Add(blocks[4]);
			//((Preparation)blocks[4]).blocksBody.Add(blocks[5]);

			//blocks.Add(new Terminator("Конец", false)); // 6 end
			//return blocks;

			// 1
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new Preparation("i = 0, i < n, i++")); // 1 for

			//blocks.Add(new DecisionFull("123 > abc")); // 2 then if
			//blocks[2].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[2]);

			//blocks.Add(new Process("int a = 91883718464")); // 3 then then
			//blocks[3].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[3]);
			//blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			//blocks.Add(new Preparation("i = 7, i > k, i--")); // 4 then else
			//blocks[4].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[4]);
			//blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			//blocks.Add(new Process("int a = 5")); // 5 then else then
			//blocks[5].blocksPreparation.Add(blocks[1]);
			//((Preparation)blocks[1]).blocksBody.Add(blocks[5]);
			//blocks[5].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[5]);
			//blocks[5].blocksPreparation.Add(blocks[4]);
			//((Preparation)blocks[4]).blocksBody.Add(blocks[5]);

			//blocks.Add(new Terminator("Конец", false)); // 6 end
			//return blocks;


			// 2
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new DecisionLoop("а > b?")); // 1 while

			//blocks.Add(new DecisionFull("123 > abc?")); // 2 then if
			//blocks[2].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[2]);

			//blocks.Add(new Process("int a = 91883718464")); // 3 then then
			//blocks[3].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[3]);
			//blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			//blocks.Add(new DecisionFull("a == 7?")); // 4 then else if
			//blocks[4].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[4]);
			//blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			//blocks.Add(new Decision("a < 2?")); // 5 then else then if
			//blocks[5].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[5]);
			//blocks[5].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[5]);
			//blocks[5].blocksDecisionFullThen.Add(blocks[4]);
			//((DecisionFull)blocks[4]).blocksBody.Add(blocks[5]);

			//blocks.Add(new Process("k = 0")); // 6 then else then then
			//blocks[6].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[6]);
			//blocks[6].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[6]);
			//blocks[6].blocksDecisionFullThen.Add(blocks[4]);
			//((DecisionFull)blocks[4]).blocksBody.Add(blocks[6]);
			//blocks[6].blocksDecision.Add(blocks[5]);
			//((Decision)blocks[5]).blocksBody.Add(blocks[6]);

			//blocks.Add(new Process("k = 2")); // 7 then else else
			//blocks[7].blocksDecisionLoop.Add(blocks[1]);
			//((DecisionLoop)blocks[1]).blocksBody.Add(blocks[7]);
			//blocks[7].blocksDecisionFullElse.Add(blocks[2]);
			//((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[7]);
			//blocks[7].blocksDecisionFullElse.Add(blocks[4]);
			//((DecisionFull)blocks[4]).blocksBodyElse.Add(blocks[7]);

			//blocks.Add(new Terminator("Конец", false)); // 8 end
			//return blocks;

			// 3
			//blocks.Add(new Terminator("Начало", true)); // 0 begin

			//blocks.Add(new Terminator("Конец", false)); // 1 end
			//return blocks;
		}
		#endregion
	}
}
