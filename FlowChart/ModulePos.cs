using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowChart
{
	class ModulePos
	{
		public static IBlock GetLast(List<IBlock> lst)
		// возвращает последний объект из заданного списка
		{
			return lst[lst.Count - 1];
		}

		public static void SetPositionsX(List<IBlock> blocks)
		// устанавливает позиции по X всех блоков
		{
			foreach (IBlock block in blocks)
			{
				if (block.isBranchRight) SetPosBranchRight(block);
			}
		}

		public static void SetPosBranchRight(IBlock block)
		// устанавливает позиции всех блоков, зависящих от данного блока, содержащего ветвление справа
		{
			block.shiftRight += block.xDistance;

			if (CheckShiftLastBlock(block))
			{
				IncreaseShiftRight(block.blocksDecision, block.xDistance);
				IncreaseShiftRight(block.blocksDecisionLoop, block.xDistance);
				IncreaseShiftRight(block.blocksPreparation, block.xDistance);
			}
		}

		public static void IncreaseShiftRight(List<IBlock> blocks, int shift)
		// увеличивает сдвиг всех блоков из списка
		{
			foreach (IBlock block in blocks) block.shiftRight += shift;
		}

		public static bool CheckShiftLastBlock(IBlock block)
		// проверка, не были ли ветвления внешних циклов/условий сдвинуты ранее
		{
			bool isShift = false;
			if (block.blocksDecisionFull.Count > 0)
			{
				DecisionFull last = (DecisionFull)GetLast(block.blocksDecisionFull);
				if (last.blocksBodyElse[0].xLeft == block.xRight + block.xDistance) isShift = true;
			}
			if (block.blocksDecision.Count > 0)
			{
				if (GetLast(block.blocksDecision).shiftRight == block.xDistance) isShift = true;
			}
			if (block.blocksDecisionLoop.Count > 0)
			{
				if (GetLast(block.blocksDecisionLoop).shiftRight == block.xDistance) isShift = true;
			}
			if (block.blocksPreparation.Count > 0)
			{
				if (GetLast(block.blocksPreparation).shiftRight == block.xDistance) isShift = true;
			}
			return isShift;
		}
	}
}
