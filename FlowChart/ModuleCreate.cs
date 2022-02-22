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

			blocks.Add(new Preparation("i = 0, i < n, i++")); // 1 for

			blocks.Add(new DecisionFull("123 > abc")); // 2 then if
			blocks[2].blocksPreparation.Add(blocks[1]);
			((Preparation)blocks[1]).blocksBody.Add(blocks[2]);

			blocks.Add(new Process("int a = 91883718464")); // 3 then then
			blocks[3].blocksPreparation.Add(blocks[1]);
			((Preparation)blocks[1]).blocksBody.Add(blocks[3]);
			blocks[3].blocksDecisionFullThen.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBody.Add(blocks[3]);

			blocks.Add(new Preparation("i = 7, i > k, i--")); // 4 then else
			blocks[4].blocksPreparation.Add(blocks[1]);
			((Preparation)blocks[1]).blocksBody.Add(blocks[4]);
			blocks[4].blocksDecisionFullElse.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[4]);

			blocks.Add(new Process("int a = 5")); // 5 then else then
			blocks[5].blocksPreparation.Add(blocks[1]);
			((Preparation)blocks[1]).blocksBody.Add(blocks[5]);
			blocks[5].blocksDecisionFullElse.Add(blocks[2]);
			((DecisionFull)blocks[2]).blocksBodyElse.Add(blocks[5]);
			blocks[5].blocksPreparation.Add(blocks[4]);
			((Preparation)blocks[4]).blocksBody.Add(blocks[5]);

			blocks.Add(new Terminator("Конец", false)); // 6 end
			return blocks;
		}
	}
}
