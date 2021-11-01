using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	public interface IBlock
	{
		int xLeft { get; set; }
		int xRight { get; set; }
		int yUp { get; set; }
		int yDown { get; set; }
		int xCenter { get; set; }
		int yCenter { get; set; }
		int xSizeShape { get; set; }
		int ySizeShape { get; set; }
		int xDistance { get; set; }
		int yDistance { get; set; }
		int shiftLeft { get; set; }
		int shiftRight { get; set; }
		bool isBranchLeft { get; set; }
		bool isBranchRight { get; set; }
		bool isBranchBody { get; set; }
		List<IBlock> blocksDecision { get; set; }
		List<IBlock> blocksDecisionFullThen { get; set; }
		List<IBlock> blocksDecisionFullElse { get; set; }
		List<IBlock> blocksDecisionLoop { get; set; }
		List<IBlock> blocksPreparation { get; set; }
		void SetPosition(int _xLeft, int _yUp);
		void DrawShape(Graphics graphic);
		void DrawText(Graphics graphic);
		void SetConnectorsPosition();
		void DrawConnectors(Graphics graphic);
	}
}
