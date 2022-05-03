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
		public static int GetPictureSizeX(List<IBlock> blocks)
		{
			int xSize = 0;
			foreach (IBlock block in blocks)
			{
				if (block.xRight + block.shiftRight + block.xDistance*2 > xSize)
				{
					xSize = block.xRight + block.shiftRight + block.xDistance*2;
				}
			}
			return xSize;
		}

		public static int GetPictureSizeY(List<IBlock> blocks)
		{
			int ySize = GetLast(blocks).yUp + blocks[1].ySizeShape;
			return ySize;
		}
	}
}
