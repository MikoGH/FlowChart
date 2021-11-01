using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Decision : Shape, IBlock
    //элемент блок-схемы - неполное условие
    {
        public SolidBrush brush = new SolidBrush(Color.FromArgb(230, 230, 130));

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = true;
        public bool isBranchBody { get; set; } = false;

        public List<IBlock> blocksBody = new List<IBlock> { }; // блоки, входящие в тело если

        public Decision(string _text)
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
