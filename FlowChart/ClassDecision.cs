using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
{
    public class Decision : Shape, IBlock
    //элемент блок-схемы - условие
    {
        public SolidBrush brush = new SolidBrush(Color.LightGreen);
        string text;
        int xLeft;
        int xRight;
        int yUp;
        int yDown;
        int xCenter;
        int yCenter;

        List<Point[]> connectorsPoints = new List<Point[]> { }; // точки начала и конца линий связи блоков

        List<IBlock> blocksDecisionOut = new List<IBlock> { }; // блоки условия, в которых находится данный
        List<IBlock> blocksBody1 = new List<IBlock> { }; // блоки, входящие в тело если
        List<IBlock> blocksBody2 = new List<IBlock> { }; // блоки, входящие в тело иначе

        public Decision(string _text)
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

        public void DrawText(Graphics graphic)
        // отрисовать текст
        {
            SetStringFormatCenter();
            graphic.DrawString(text, fontMain, brushText, new RectangleF(xLeft, yUp, xSizeShape, ySizeShape), stringFormatMain);
        }

        public void DrawConnectors(Graphics graphic)
		{
			foreach (Point[] connector in connectorsPoints)
			{
                graphic.DrawLine(penMain, connector[0], connector[1]);
			}
		}
    }
}
