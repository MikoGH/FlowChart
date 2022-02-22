using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace FlowChart
{
	partial class Module
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
				foreach (DecisionFull blockDecision in blockPrev.blocksDecisionFullElse.Except(block.blocksDecisionFullElse).ToList())
				{
					blocksForShift = blocks.Skip(i).ToList();
					foreach (IBlock blockDecision2 in block.blocksDecisionFullThen)
					{
						blocksForShift = blocksForShift.Except(((DecisionFull)blockDecision2).blocksBodyElse).ToList();
					}
					IncreaseYPos(blocksForShift, -Math.Min(blockDecision.tmpShiftDownThen, blockDecision.tmpShiftDownElse));
				}
			}

			// сдвиг ветвей снизу
			for (int i = 1; i < blocks.Count; i++)
			{
				IBlock block = blocks[i];
				if (block is DecisionLoop)
				{
					for (int j = i+1; j < blocks.Count; j++)
					{
						if (!(blocks[j].blocksDecisionLoop.Contains(block)))
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
						if (!(blocks[j].blocksPreparation.Contains(block)))
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
						if (!(blocks[j].blocksDecision.Contains(block)))
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
						if (!(blocks[j].blocksDecisionFullThen.Contains(block)) && !(blocks[j].blocksDecisionFullElse.Contains(block)))
						{
							block.shiftDown = blocks[j].yUp - block.yDown;
							DecreaseShiftBranch(block, blocks[j]);
							break;
						}
					}
				}
			}
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

		//public static void SetPositionsY(List<IBlock> blocks)
		//// устанавливает позиции по Y всех блоков
		//{
		//	for (int i = 1; i < blocks.Count; i++)
		//	{
		//		IBlock block = blocks[i];
		//		IBlock blockPrev = blocks[i - 1];
		//		SetPosBranchDown(block);

		//		int maxShift = blockPrev.yDown + blockPrev.yDistance;
		//		maxShift = Math.Max(maxShift, GetMaxShiftDown(blockPrev.blocksDecision.Except(block.blocksDecision).ToList()));
		//		maxShift = Math.Max(maxShift, GetMaxShiftDown(blockPrev.blocksDecisionFullThen.Except(block.blocksDecisionFullThen).ToList()));
		//		maxShift = Math.Max(maxShift, GetMaxShiftDown(blockPrev.blocksDecisionFullElse.Except(block.blocksDecisionFullElse).ToList()));
		//		maxShift = Math.Max(maxShift, GetMaxShiftDown(blockPrev.blocksDecisionLoop.Except(block.blocksDecisionLoop).ToList()));
		//		maxShift = Math.Max(maxShift, GetMaxShiftDown(blockPrev.blocksPreparation.Except(block.blocksPreparation).ToList()));
		//		block.SetPositionY(maxShift);

		//		if (block.blocksDecisionFullElse.Count > 0)
		//		{
		//			DecisionFull last = (DecisionFull)GetLast(block.blocksDecisionFullElse);
		//			if (block == last.blocksBodyElse[0]) block.SetPositionY(last.yDown + last.yDistance);
		//		}

		//		if (block is DecisionLoop) block.SetPositionY(block.yUp + block.yDistance);
		//	}
		//}

		//public static void SetPosBranchDown(IBlock block)
		//// устанавливает сдвиг снизу всех блоков, зависящих от данного блока
		//{
		//	int shift;
		//	if (block is DecisionLoop | block is Preparation)
		//	{
		//		block.shiftDown = block.yDistance * 3;
		//		shift = block.ySizeShape + block.yDistance * 3;
		//	}
		//	else if (block is Decision | block is DecisionFull)
		//	{
		//		block.shiftDown = block.yDistance * 2; 
		//		shift = block.ySizeShape + block.yDistance * 2;
		//	}
		//	else
		//	{
		//		block.shiftDown = block.yDistance;
		//		shift = block.ySizeShape + block.yDistance;
		//	}
		//	IncreaseShiftDown(block.blocksDecisionLoop);
		//	IncreaseShiftDown(block.blocksPreparation);
		//	IncreaseShiftDown(block.blocksDecision);
		//	IncreaseShiftDown(block.blocksDecisionFullThen);
		//	IncreaseShiftDown(block.blocksDecisionFullElse);
		//	//IncreaseShiftDown(block.blocksDecisionLoop, shift);
		//	//IncreaseShiftDown(block.blocksPreparation, shift);
		//	//IncreaseShiftDown(block.blocksDecision, shift);
		//	//IncreaseShiftDown(block.blocksDecisionFullThen, shift);
		//	//IncreaseShiftDown(block.blocksDecisionFullElse, shift);
		//}


		//static void IncreaseShiftDown(List<IBlock> blocks)
		//// увеличивает сдвиг снизу всех блоков из списка
		//{
		//	foreach (IBlock block in blocks)
		//	{
		//		//if (CheckShiftDown(block, shift)) block.shiftDown += shift;
		//		int maxShift = 0;
		//		if (block is Decision) maxShift = GetMaxShiftDown(((Decision)block).blocksBody) + block.yDistance;
		//		if (block is DecisionLoop) maxShift = GetMaxShiftDown(((DecisionLoop)block).blocksBody) + block.yDistance * 2;
		//		if (block is Preparation) maxShift = GetMaxShiftDown(((Preparation)block).blocksBody) + block.yDistance * 2;
		//		if (block is DecisionFull)
		//		{
		//			maxShift = GetMaxShiftDown(((DecisionFull)block).blocksBody) + block.yDistance;
		//			maxShift = Math.Max(maxShift, GetMaxShiftDown(((DecisionFull)block).blocksBodyElse)) + block.yDistance;
		//		}

		//		block.shiftDown = Math.Max(block.shiftDown, block.shiftDown + (maxShift - (block.yDown + block.shiftDown)));
		//	}
		//}

		//static void IncreaseShiftY(List<IBlock> blocks, int shift)
		//// увеличивает сдвиг по y всех блоков из списка
		//{
		//	foreach (IBlock block in blocks) block.SetPositionY(block.yUp + shift);
		//}


		//static int GetMaxShiftDown(List<IBlock> blocks)
		//// находит максимальный сдвиг снизу у блоков из заданного списка
		//{
		//	int maxShift = 0;
		//	foreach (IBlock block in blocks)
		//	{
		//		maxShift = Math.Max(maxShift, block.yDown + block.shiftDown);
		//	}
		//	return maxShift;
		//}


		////static bool CheckShiftDown(IBlock block, int shift)
		//// проверяет, нужно ли увеличивать сдвиг снизу всех внешних циклов/условий
		////{
		////	bool isShift = true;
		////	//if (block.blocksDecisionFullThen.Count > 0)
		////	//{
		////	//	IBlock last = GetLast(block.blocksDecisionFullThen);
		////	//	if (last.yDown + last.shiftDown > block.yDown + shift) isShift = false;
		////	//}
		////	if (block.blocksDecisionFullElse.Count > 0)
		////	{
		////		IBlock last = GetLast(block.blocksDecisionFullElse);
		////		if (last.yDown + last.shiftDown > block.yDown + shift) isShift = false;
		////	}
		////	return isShift;
		////}

		//static bool CheckShiftDown(IBlock block, int shift)
		//// проверяет, нужно ли увеличивать сдвиг снизу внешнего цикла/условия
		//{
		//	bool isShift = true;
		//	List<IBlock> blocksBody = new List<IBlock> { };
		//	if (block is Decision) blocksBody = ((Decision)block).blocksBody;
		//	if (block is DecisionLoop) blocksBody = ((DecisionLoop)block).blocksBody;
		//	if (block is Preparation) blocksBody = ((Preparation)block).blocksBody;
		//	if (block is DecisionFull) blocksBody = ((DecisionFull)block).blocksBody.Intersect(((DecisionFull)block).blocksBodyElse).ToList();
		//	//if (blockShift.yDown + blockShift.shiftDown > block.yDown + shift) isShift = false;
		//	foreach (IBlock blockBody in blocksBody)
		//	{
		//		if (block.yDown + block.shiftDown > blockBody.yDown + blockBody.shiftDown + shift) isShift = false;
		//	}
		//	return isShift;
		//}
	}
}
