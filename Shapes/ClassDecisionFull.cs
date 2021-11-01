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
        public SolidBrush brush = new SolidBrush(Color.FromArgb(230,230,130));

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

        public void SetPosition(int _xLeft, int _yUp)
        // установить позиции отрисовки
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            xCenter = xLeft + xSizeShape / 2;

            yUp = _yUp;
            yDown = yUp + ySizeShape;
            yCenter = yUp + ySizeShape / 2;
        }

        public void SetConnectorsPosition()
		{
            connectorsPoints.Add(new Point[]
                {
                    new Point(xCenter, yDown),
                    new Point(xCenter, yDown + yDistance)
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
