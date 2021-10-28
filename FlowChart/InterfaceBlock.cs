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
		void SetPosition(int _xLeft, int _yUp);
		void DrawShape(Graphics graphic);
		void DrawText(Graphics graphic);
		void SetConnectorsPosition();
		void DrawConnectors(Graphics graphic);
	}
}
