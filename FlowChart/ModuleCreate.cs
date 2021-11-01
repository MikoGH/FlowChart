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
	partial class Module
	{
		public static List<IBlock> CreateBlocks(List<IBlock> blocks)
		{
			// тут будет алгоритм преобразования кода в список объектов 
			// пока что объекты создаются вручную

			blocks.Add(new Terminator("Начало", true)); // 0 begin

			blocks.Add(new Decision("k < 0")); // 1

			blocks.Add(new DecisionFull("123 > abc")); // 2 if
			blocks[2].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[2]);

			blocks.Add(new Preparation("i = 0, i < n, i++")); // 3 then
			blocks[3].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[3]);
			blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			blocks.Add(new DecisionLoop("i < 5")); // 4 then
			blocks[4].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[4]);
			blocks[4].blocksDecisionFullThen.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBody.Add(blocks[4]);
			blocks[4].blocksPreparation.Add(blocks[3]);
			((Preparation)blocks[3]).blocksBody.Add(blocks[4]);

			blocks.Add(new Process("int a = 91883718464")); // 5 then
			blocks[5].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[5]);
			blocks[5].blocksDecisionFullThen.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBody.Add(blocks[5]);
			blocks[5].blocksPreparation.Add(blocks[3]);
			((Preparation)blocks[3]).blocksBody.Add(blocks[5]);
			blocks[5].blocksDecisionLoop.Add(blocks[4]);
			((DecisionLoop)blocks[4]).blocksBody.Add(blocks[5]);

			blocks.Add(new Decision("987 > sdf")); // 6 else if
			blocks[6].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[6]);
			blocks[6].blocksDecisionFullElse.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[6]);

			blocks.Add(new Process("int a = 0")); // 7 else then
			blocks[7].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[7]);
			blocks[7].blocksDecisionFullElse.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[7]);
			blocks[7].blocksDecision.Add(blocks[6]);
			((Decision)blocks[6]).blocksBody.Add(blocks[7]);

			blocks.Add(new Terminator("Конец")); // 8 end
			return blocks;
		}
	}
}
