using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Modules;
using Shapes;
using FlowChart;

namespace UnitTestProjectFC
{
	[TestClass]
	public class UnitTest1
	{
		#region Текст
		[TestMethod]
		public void TestMethodSetTextPreparation()
		{
			// инициализация
			List<IBlock> blocks = new List<IBlock>();
			blocks.Add(new Preparation("zzz"));
			blocks.Add(new Preparation("int i = 0 ; i < 5 ; i++"));
			blocks.Add(new Preparation("int i=0;i<=k;i+=2"));

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Preparation("zzz"));
			blocksExp.Add(new Preparation("для int i\nот 0 до 5 \nс шагом 1"));
			blocksExp.Add(new Preparation("для int i\nот 0 до k вкл.\nс шагом 2"));

			// действие
			Module.SetTextBlocks(blocks);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodSetTextDecision()
		{
			// инициализация
			List<IBlock> blocks = new List<IBlock>();
			blocks.Add(new Decision("zzz"));
			blocks.Add(new DecisionFull("k < 5"));

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Decision("zzz ?"));
			blocksExp.Add(new DecisionFull("k < 5 ?"));

			// действие
			Module.SetTextBlocks(blocks);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodSetTextDecisionLoop()
		{
			// инициализация
			List<IBlock> blocks = new List<IBlock>();
			blocks.Add(new DecisionLoop("zzz"));
			blocks.Add(new DecisionLoop("k < 5"));

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new DecisionLoop("пока zzz"));
			blocksExp.Add(new DecisionLoop("пока k < 5"));

			// действие
			Module.SetTextBlocks(blocks);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}
		#endregion

		#region Вспомогательные методы
		[TestMethod]
		public void TestMethodGetLast()
		{
			// инициализация
			List<IBlock> blocks = new List<IBlock>();
			blocks.Add(new Terminator("Начало", true));
			blocks.Add(new Terminator("Конец", false));

			// ожидаемый результат
			IBlock blockExp = new Terminator("Конец", false);

			// действие
			IBlock block = Module.GetLast(blocks);
			IBlock block2 = Shape.GetLast(blocks);

			// проверка
			Assert.AreEqual(block, blockExp);
			Assert.AreEqual(block2, blockExp);
		}
		#endregion

		#region Создание блоков - проверка типа
		[TestMethod]
		public void TestMethodIsPreparation()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("for(){}");
			codes.Add("for()");
			codes.Add("while");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(true);
			boolsExp.Add(true);
			boolsExp.Add(false);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsPreparation(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}

		[TestMethod]
		public void TestMethodIsDecisionLoop()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("for(){}");
			codes.Add("while(){}");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(false);
			boolsExp.Add(true);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsDecisionLoop(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}

		[TestMethod]
		public void TestMethodIsDecision()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("if(){}");
			codes.Add("if(){}else{}");
			codes.Add("if(){}else{k=0;}");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(true);
			boolsExp.Add(true);
			boolsExp.Add(false);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsDecision(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}

		[TestMethod]
		public void TestMethodIsDecisionFull()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("if(){}");
			codes.Add("if(){}else{}");
			codes.Add("if(){}else{k=0;}");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(false);
			boolsExp.Add(false);
			boolsExp.Add(true);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsDecisionFull(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}

		[TestMethod]
		public void TestMethodIsData()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("zzz;");
			codes.Add("Console.WriteLine()");
			codes.Add("Console.WriteLine();");
			codes.Add("Console.Write();");
			codes.Add("Console.ReadLine();");
			codes.Add("Console.Read();");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(false);
			boolsExp.Add(false);
			boolsExp.Add(true);
			boolsExp.Add(true);
			boolsExp.Add(true);
			boolsExp.Add(true);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsData(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}

		[TestMethod]
		public void TestMethodIsProcess()
		{
			// инициализация
			List<string> codes = new List<string>();
			codes.Add("zzz;");
			codes.Add("n=0");

			// ожидаемый результат
			List<bool> boolsExp = new List<bool>();
			boolsExp.Add(true);
			boolsExp.Add(false);

			// действие
			List<bool> bools = new List<bool>();
			foreach (var item in codes)
				bools.Add(Module.IsProcess(item));

			// проверка
			CollectionAssert.AreEqual(bools, boolsExp);
		}
		#endregion

		#region Создание блоков
		[TestMethod]
		public void TestMethodCreatePreparation()
		{
			// инициализация
			string code = "for(int i = 0 ; i < 5 ; i++){}";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Preparation("int i = 0 ; i < 5 ; i++"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreatePreparation2()
		{
			// инициализация
			string code = "for(int i = 0 ; i < 5 ; i++)k=0;";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Preparation("int i = 0 ; i < 5 ; i++"));
			blocksExp.Add(new Process("k=0"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateDecisionLoop()
		{
			// инициализация
			string code = "while(i>0){}";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new DecisionLoop("i>0"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateDecisionLoop2()
		{
			// инициализация
			string code = "while(i>0)k=0;";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new DecisionLoop("i>0"));
			blocksExp.Add(new Process("k=0"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateDecision()
		{
			// инициализация
			string code = "if(true){}";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Decision("true"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateDecision2()
		{
			// инициализация
			string code = "if(true)k=0;";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Decision("true"));
			blocksExp.Add(new Process("k=0"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateDecisionFullProcess()
		{
			// инициализация
			string code = "if(true){}else{k=0;}";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new DecisionFull("true"));
			blocksExp.Add(new Process("k=0"));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateData()
		{
			// инициализация
			string code = "Console.WriteLine();";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Data(""));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}

		[TestMethod]
		public void TestMethodCreateData2()
		{
			// инициализация
			string code = "k = Console.ReadLine('Ввод');";
			List<IBlock> blocks = new List<IBlock>();

			// ожидаемый результат
			List<IBlock> blocksExp = new List<IBlock>();
			blocksExp.Add(new Data("'Ввод'"));
			blocksExp.Add(new Data("k "));

			// действие
			blocks = Module.CreateBlocks(ref code);

			// проверка
			CollectionAssert.AreEqual(blocks, blocksExp);
		}
		#endregion
	}
}
