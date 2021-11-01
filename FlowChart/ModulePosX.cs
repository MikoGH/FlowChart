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
		static IBlock GetLast(List<IBlock> lst)
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
				if (block.isBranchLeft) SetPosBranchLeft(block);
				if (block.isBranchBody) SetPosBranchBody((DecisionFull)block);

				if (block.blocksDecisionLoop.Count > 0)
				{
					if (block.blocksDecisionLoop[0].xLeft - block.blocksDecisionLoop[0].shiftLeft < block.xDistance)
					{
						IncreaseShift(blocks, block.xDistance);
					}
				}
				if (block.blocksPreparation.Count > 0)
				{
					if (block.blocksPreparation[0].xLeft - block.blocksPreparation[0].shiftLeft < block.xDistance)
					{
						IncreaseShift(blocks, block.xDistance);
					}
				}
			}
		}


		static void SetPosBranchRight(IBlock block)
		// устанавливает позиции всех блоков, зависящих от данного блока, содержащего ветвление справа
		{
			block.shiftRight += block.xDistance;

			if (CheckShiftRightLastBlock(block, block.xDistance))
			{
				foreach (IBlock blockDecision in block.blocksDecisionFullThen)
				{
					IncreaseShift(((DecisionFull)blockDecision).blocksBodyElse, block.xDistance);
				}

				IncreaseShiftRight(block.blocksDecision, block.xDistance);
				IncreaseShiftRight(block.blocksDecisionLoop, block.xDistance);
				IncreaseShiftRight(block.blocksPreparation, block.xDistance);
			}
		}

		static void SetPosBranchLeft(IBlock block)
		// устанавливает позиции всех блоков, зависящих от данного блока, содержащего ветвление слева
		{
			block.shiftLeft += block.xDistance;

			if (CheckShiftLeftLastBlock(block, block.xDistance))
			{
				if (block.blocksDecisionFullElse.Count == 0)
				{
					IncreaseShiftLeft(block.blocksDecisionLoop, block.xDistance);
					IncreaseShiftLeft(block.blocksPreparation, block.xDistance);
				}
				else
				{
					DecisionFull last = (DecisionFull)GetLast(block.blocksDecisionFullElse);
					IncreaseShiftLeft(block.blocksDecisionLoop.Intersect(last.blocksBodyElse).ToList(), block.xDistance);
					IncreaseShiftLeft(block.blocksPreparation.Intersect(last.blocksBodyElse).ToList(), block.xDistance);

					foreach (IBlock blockDecision in last.blocksDecisionFullThen)
					{
						IncreaseShift(((DecisionFull)blockDecision).blocksBodyElse, block.xDistance);
					}
					IncreaseShift(last.blocksBodyElse, block.xDistance);
					IncreaseShiftRight(last.blocksDecision, block.xDistance);
					IncreaseShiftRight(last.blocksDecisionLoop, block.xDistance);
					IncreaseShiftRight(last.blocksPreparation, block.xDistance);
				}
			}
		}

		static void SetPosBranchBody(DecisionFull block)
		// устанавливает позиции всех блоков, зависящих от данного блока, содержащего особое ветвление с телом
		{
			IncreaseShift(block.blocksBodyElse, block.xSizeShape + block.xDistance);

			if (CheckShiftRightLastBlock(block, block.xSizeShape + block.xDistance))
			{
				foreach (IBlock blockDecision in block.blocksDecisionFullThen)
				{
					IncreaseShift(((DecisionFull)blockDecision).blocksBodyElse, block.xSizeShape + block.xDistance);
				}

				IncreaseShiftRight(block.blocksDecision, block.xSizeShape + block.xDistance);
				IncreaseShiftRight(block.blocksDecisionLoop, block.xSizeShape + block.xDistance);
				IncreaseShiftRight(block.blocksPreparation, block.xSizeShape + block.xDistance);
			}
		}


		static void IncreaseShiftRight(List<IBlock> blocks, int shift)
		// увеличивает сдвиг ветвления справа всех блоков из списка
		{
			foreach (IBlock block in blocks) block.shiftRight += shift;
		}

		static void IncreaseShiftLeft(List<IBlock> blocks, int shift)
		// увеличивает сдвиг ветвления слева всех блоков из списка
		{
			foreach (IBlock block in blocks) block.shiftLeft += shift;
		}


		static void IncreaseShift(List<IBlock> blocks, int shift)
		// увеличивает сдвиг всех блоков из списка
		{
			foreach (IBlock block in blocks) block.SetPositionX(block.xLeft + shift);
		}


		static bool CheckShiftRightLastBlock(IBlock block, int shift)
		// проверка, не были ли ветвления справа внешних циклов/условий сдвинуты ранее на заданное значение
		{
			bool isShift = false;
			if (block.blocksDecisionFullThen.Count > 0)
			{
				DecisionFull last = (DecisionFull)GetLast(block.blocksDecisionFullThen);
				if (last.blocksBodyElse[0].xLeft <= block.xRight + shift) isShift = true;
			}
			if (block.blocksDecision.Count > 0)
			{
				IBlock last = GetLast(block.blocksDecision);
				if (last.xRight + last.shiftRight <= block.xRight + shift) isShift = true;
			}
			if (block.blocksDecisionLoop.Count > 0)
			{
				IBlock last = GetLast(block.blocksDecisionLoop);
				if (last.xRight + last.shiftRight <= block.xRight + shift) isShift = true;
			}
			if (block.blocksPreparation.Count > 0)
			{
				IBlock last = GetLast(block.blocksPreparation);
				if (last.xRight + last.shiftRight <= block.xRight + shift) isShift = true;
			}
			return isShift;
		}

		static bool CheckShiftLeftLastBlock(IBlock block, int shift)
		// проверка, не были ли ветвления слева внешних циклов сдвинуты ранее на заданное значение
		{
			bool isShift = false;
			if (block.blocksDecisionLoop.Count > 0)
			{
				IBlock last = GetLast(block.blocksDecisionLoop);
				if (last.xLeft - last.shiftLeft <= block.xLeft - shift) isShift = true;
			}
			if (block.blocksPreparation.Count > 0)
			{
				IBlock last = GetLast(block.blocksPreparation);
				if (last.xLeft - last.shiftLeft <= block.xLeft - shift) isShift = true;
			}
			return isShift;
		}
	}
}
