using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowChart
{
	class ModulesPos
	{
		static IBlock GetLast(List<IBlock> lst)
		// возвращает последний объект из заданного списка
		{
			return lst[lst.Count - 1];
		}

		static void SetPositionsX(List<IBlock> blocks)
		// устанавливает позиции по X всех блоков
		{

		}
	}
}
