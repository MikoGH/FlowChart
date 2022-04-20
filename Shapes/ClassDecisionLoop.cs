using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class DecisionLoop : Shape, IBlock
    //элемент блок-схемы - цикл while
    {
        public SolidBrush brush = new SolidBrush(Color.FromArgb(250, 180, 130));

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = true;
        public bool isBranchRight { get; set; } = true;
        public bool isBranchBody { get; set; } = false;

        public List<IBlock> blocksBody = new List<IBlock> { }; // блоки, входящие в тело если

        public DecisionLoop(string _text)
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
                new Point(xRight + shiftRight, yCenter)
            }); 
            connectorsPoints.Add(new Point[]
            {
                new Point(xRight + shiftRight, yCenter),
                new Point(xRight + shiftRight, yDown + shiftDown - yDistance)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xRight + shiftRight, yDown + shiftDown - yDistance),
                new Point(xCenter, yDown + shiftDown - yDistance)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xCenter, yDown + shiftDown - yDistance),
                new Point(xCenter, yDown + shiftDown)
            });

            connectorsPoints.Add(new Point[]
            {
                new Point(xLeft - shiftLeft, yCenter),
                new Point(xLeft, yCenter)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xLeft - shiftLeft, yDown + shiftDown - 2*yDistance),
                new Point(xLeft - shiftLeft, yCenter)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xCenter, yDown + shiftDown - 2*yDistance),
                new Point(xLeft - shiftLeft, yDown + shiftDown - 2*yDistance)
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
