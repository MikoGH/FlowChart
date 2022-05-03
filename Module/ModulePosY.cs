using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace Modules
{
	public partial class Module
	{
		public static void SetPositionsY(List<IBlock> blocks)
		// устанавливает позиции по Y всех блоков
		{
			for (int i = 1; i < blocks.Count; i++)
			{
				IBlock block = blocks[i];
				IBlock blockPrev = blocks[i - 1];

				// сдвиг всех последующих блоков, не входящих в тело else условий, в которые входит текущий блок
				List<IBlock> blocksForShift = blocks.Skip(i+1).ToList(); 
				foreach (IBlock blockDecision in block.blocksDecisionFullThen)
				{
					blocksForShift = blocksForShift.Except(((DecisionFull)blockDecision).blocksBodyElse).ToList();
				}

				IncreaseYPos(blocksForShift, block.ySizeShape + block.yDistance);

				// дополнительный сдвиг всех последующих блоков, не входящих в тело данного
				int shift = 0;
				if (block is DecisionLoop)
				{
					blocksForShift = blocksForShift.Except(((DecisionLoop)block).blocksBody).ToList();
					shift += block.yDistance * 2;
				}
				else if (block is Preparation)
				{
					blocksForShift = blocksForShift.Except(((Preparation)block).blocksBody).ToList();
					shift += block.yDistance * 2;
				}
				else if (block is Decision)
				{
					blocksForShift = blocksForShift.Except(((Decision)block).blocksBody).ToList();
					shift += block.yDistance;
				}
				else if (block is DecisionFull)
				{
					blocksForShift = blocksForShift.Except(((DecisionFull)block).blocksBody).ToList();
					blocksForShift = blocksForShift.Except(((DecisionFull)block).blocksBodyElse).ToList();
					shift += block.yDistance;
				}
				IncreaseYPos(blocksForShift, shift);

				// временный сдвиг в теле if всех условий, в которые входит текущий блок
				foreach (DecisionFull blockDecision in block.blocksDecisionFullThen)
				{
					blockDecision.tmpShiftDownThen += shift + block.ySizeShape + block.yDistance;
				}

				// временный сдвиг в теле else всех условий, в которые входит текущий блок
				foreach (DecisionFull blockDecision in block.blocksDecisionFullElse)
				{
					blockDecision.tmpShiftDownElse += shift + block.ySizeShape + block.yDistance;
				}

				// сдвиг всех последующих блоков на разницу между телом if и else непосредственно после полного условия
				//
				//foreach (DecisionFull blockDecision in blockPrev.blocksDecisionFullElse.Except(block.blocksDecisionFullElse).ToList())
				//{
				//	blocksForShift = blocks.Skip(i).ToList();
				//	foreach (DecisionFull blockDecision2 in block.blocksDecisionFullThen)
				//	{
				//		blocksForShift = blocksForShift.Except(blockDecision2.blocksBodyElse).ToList();
				//	}
				//	IncreaseYPos(blocksForShift, -Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse));
				//}
				//foreach (DecisionFull blockDecision in blockPrev.blocksDecisionFullElse.Except(block.blocksDecisionFullElse).ToList())
				//{
				//	blocksForShift = blocks.Skip(i).ToList();
				//	foreach (DecisionFull blockDecision2 in blockPrev.blocksDecisionFullThen)
				//	{
				//		blocksForShift = blocksForShift.Except(blockDecision2.blocksBodyElse).ToList();
				//	}
				//	IncreaseYPos(blocksForShift, -Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse));
				//	foreach (DecisionFull blockDecision2 in blockPrev.blocksDecisionFullThen)
				//	{
				//		blockDecision2.tmpShiftDownThen -= Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse);
				//	}
				//	foreach (DecisionFull blockDecision2 in blockPrev.blocksDecisionFullElse)
				//	{
				//		blockDecision2.tmpShiftDownElse -= Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse);
				//	}
				//}
				List<IBlock> blocks2 = blockPrev.blocksDecisionFullElse.Except(block.blocksDecisionFullElse).ToList();
				blocks2.Reverse();
				foreach (DecisionFull blockDecision in blocks2)
				{
					blocksForShift = blocks.Skip(i).ToList();
					for (int j = i; j < blocks.Count; j++)
					{
						if (CheckSameDecisionFull(blockPrev, blocks[j]))
						{
							blocksForShift.Remove(blocks[j]);
						}
					}
					IncreaseYPos(blocksForShift, -Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse));
					foreach (DecisionFull blockDecision2 in blockPrev.blocksDecisionFullThen)
					{
						if (blockDecision2!=blockDecision)
							blockDecision2.tmpShiftDownThen -= Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse);
					}
					foreach (DecisionFull blockDecision2 in blockPrev.blocksDecisionFullElse)
					{
						if (blockDecision2 != blockDecision)
							blockDecision2.tmpShiftDownElse -= Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse);
					}
				}
			}


			// сдвиг ветвей снизу
			// нахождение первого блока, не входящего в текущее условие
			// ветвление выстраивается относительно этого блока
			for (int i = 1; i < blocks.Count; i++)
			{
				IBlock block = blocks[i];
				if (block is DecisionLoop)
				{
					for (int j = i+1; j < blocks.Count; j++)
					{
						if (!(blocks[j].blocksDecisionLoop.Contains(block)) && !CheckSameDecisionFull(block, blocks[j]))
						{
							block.shiftDown = blocks[j].yUp - block.yDown;
							DecreaseShiftBranch(block, blocks[j]);
							break;
						}
					}
				}
				else if (block is Preparation)
				{
					for (int j = i + 1; j < blocks.Count; j++)
					{
						if (!(blocks[j].blocksPreparation.Contains(block)) && !CheckSameDecisionFull(block, blocks[j]))
						{
							block.shiftDown = blocks[j].yUp - block.yDown;
							DecreaseShiftBranch(block, blocks[j]);
							break;
						}
					}
				}
				else if (block is Decision)
				{
					for (int j = i + 1; j < blocks.Count; j++)
					{
						if (!(blocks[j].blocksDecision.Contains(block)) && !CheckSameDecisionFull(block, blocks[j]))
						{
							block.shiftDown = blocks[j].yUp - block.yDown;
							DecreaseShiftBranch(block, blocks[j]);
							break;
						}
					}
				}
				else if (block is DecisionFull)
				{
					for (int j = i + 1; j < blocks.Count; j++)
					{
						if (!(blocks[j].blocksDecisionFullThen.Contains(block)) && !(blocks[j].blocksDecisionFullElse.Contains(block)) && !CheckSameDecisionFull(block, blocks[j]))
						{
							block.shiftDown = blocks[j].yUp - block.yDown;
							DecreaseShiftBranch(block, blocks[j]);
							break;
						}
					}
				}
			}
		}

		static bool CheckSameDecisionFull(IBlock block1, IBlock block2)
		// возвращает true, если два блока находятся в одном и том же полном условии, но в разных его телах if и else
		{
			foreach (DecisionFull decision in block1.blocksDecisionFullThen)
			{
				if (block2.blocksDecisionFullElse.Contains(decision))
					return true;
			}
			return false;
		}

		static void DecreaseShiftBranch(IBlock block, IBlock block2)
		{
			foreach (Decision blockDecision in block.blocksDecision.Except(block2.blocksDecision).ToList())
			{
				block.shiftDown -= block.yDistance;
			}
			foreach (DecisionFull blockDecisionFullThen in block.blocksDecisionFullThen.Except(block2.blocksDecisionFullThen).ToList())
			{
				block.shiftDown -= block.yDistance;
			}
			foreach (DecisionFull blockDecisionFullElse in block.blocksDecisionFullElse.Except(block2.blocksDecisionFullElse).ToList())
			{
				block.shiftDown -= block.yDistance;
			}
			foreach (Preparation blockPreparation in block.blocksPreparation.Except(block2.blocksPreparation).ToList())
			{
				block.shiftDown -= 2 * block.yDistance;
			}
			foreach (DecisionLoop blockDecisionLoop in block.blocksDecisionLoop.Except(block2.blocksDecisionLoop).ToList())
			{
				block.shiftDown -= 2 * block.yDistance;
			}
		}

		static void IncreaseShiftDown(List<IBlock> blocks, int shift)
		{
			foreach (IBlock block in blocks) block.shiftDown += shift;
		}

		static void IncreaseYPos(List<IBlock> blocks, int shift)
		{
			foreach (IBlock block in blocks) block.SetPositionY(block.yUp + shift);
		}
	}
}
