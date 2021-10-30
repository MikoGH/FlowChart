using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
{
	class ModuleCreate
	{
		public static List<IBlock> CreateBlocks(List<IBlock> blocks)
		{
			blocks.Add(new Terminator("Начало", true)); // 0 begin

			blocks.Add(new Decision("123 > abc")); // 1 if

			blocks.Add(new Preparation("i = 0, i < n, i++")); // 2 then
			blocks[2].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[2]);

			blocks.Add(new DecisionLoop("i < 5")); // 3 then
			blocks[3].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[3]);
			blocks[3].blocksPreparation.Add(blocks[2]);
			((Preparation)blocks[2]).blocksBody.Add(blocks[3]);

			blocks.Add(new Process("int a = 91883718464")); // 4 then
			blocks[4].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[4]);
			blocks[4].blocksPreparation.Add(blocks[2]);
			((Preparation)blocks[2]).blocksBody.Add(blocks[4]);
			blocks[4].blocksDecisionLoop.Add(blocks[3]);
			((DecisionLoop)blocks[3]).blocksBody.Add(blocks[4]);

			blocks.Add(new Decision("987 > sdf")); // 5 then if
			blocks[5].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[5]);
			blocks[5].blocksPreparation.Add(blocks[2]);
			((Preparation)blocks[2]).blocksBody.Add(blocks[5]);

			blocks.Add(new Process("int a = 0")); // 6 then then
			blocks[6].blocksDecision.Add(blocks[1]);
			((Decision)blocks[1]).blocksBody.Add(blocks[6]);
			blocks[6].blocksPreparation.Add(blocks[2]);
			((Preparation)blocks[2]).blocksBody.Add(blocks[6]);
			blocks[6].blocksDecision.Add(blocks[5]);
			((Decision)blocks[5]).blocksBody.Add(blocks[6]);

			blocks.Add(new Terminator("Конец")); // 7 end

			return blocks;
		}
	}
}
