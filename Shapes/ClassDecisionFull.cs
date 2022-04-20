using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class DecisionFull : Shape, IBlock
    //элемент блок-схемы - полное условие
    {
        public SolidBrush brush = new SolidBrush(Color.FromArgb(240, 250, 130));

        public int tmpShiftDownThen = 0;
        public int tmpShiftDownElse = 0;

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = false;
        public bool isBranchBody { get; set; } = true;

        public List<IBlock> blocksBody = new List<IBlock> { }; // блоки, входящие в тело если
        public List<IBlock> blocksBodyElse = new List<IBlock> { }; // блоки, входящие в тело иначе

        public DecisionFull(string _text)
        {
            text = _text;
        }

        public void SetConnectorsPosition()
		{
            connectorsPoints.Add(new Point[]
                {
                    new Point(xCenter, yDown),
                    new Point(xCenter, yDown + yDistance)
                });
            connectorsPoints.Add(new Point[]
                {
                    new Point(xRight, yCenter),
                    new Point(blocksBodyElse[0].xCenter, yCenter)
                });
            connectorsPoints.Add(new Point[]
                {
                    new Point(blocksBodyElse[0].xCenter, yCenter),
                    new Point(blocksBodyElse[0].xCenter, blocksBodyElse[0].yUp)
                });
			connectorsPoints.Add(new Point[]
				{
					new Point(blocksBodyElse[0].xCenter, yDown + shiftDown - yDistance),
					new Point(xCenter, yDown + shiftDown - yDistance)
				});
			connectorsPoints.Add(new Point[]
				{
					new Point(xCenter, blocksBody[blocksBody.Count-1].yDown + yDistance),
					new Point(xCenter, yDown + shiftDown)
				});
            connectorsPoints.Add(new Point[]
                {
                    new Point(blocksBodyElse[0].xCenter, blocksBodyElse[blocksBodyElse.Count-1].yDown + yDistance),
                    new Point(blocksBodyElse[0].xCenter, yDown + shiftDown - yDistance)
                });
        }

        public void DrawShape(Graphics graphic)
        // отрисовать фигуру
        {
            Point[] points =
            {
                new Point(xCenter, yUp),
                new Point(xLeft, yCenter),
                new Point(xCenter, yDown),
                new Point(xRight, yCenter)
            };
            graphic.FillPolygon(brush, points);
            graphic.DrawPolygon(penMain, points);
        }
    }
}
