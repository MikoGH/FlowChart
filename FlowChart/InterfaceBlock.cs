using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowChart
{
	public interface IBlock
	{
		int xSizeShape { get; set; }
		int ySizeShape { get; set; }
		int xDistance { get; set; }
		int yDistance { get; set; }
		int shiftLeft { get; set; }
		int shiftRight { get; set; }
		void SetPosition(int _xLeft, int _yUp);
		void DrawShape(Graphics graphic);
		void DrawText(Graphics graphic);
		void SetConnectorsPosition();
		void DrawConnectors(Graphics graphic);
	}
}
