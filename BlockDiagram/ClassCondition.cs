using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
    public class Condition : Shape, IBlock
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

        public Condition(string _text)
        {
            text = _text;
        }

        public void SetPosition(int _xLeft, int _yUp)
        // установить позиции отрисовки
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            yUp = _yUp;
            yDown = yUp + ySizeShape;
            xCenter = xLeft + xSizeShape / 2;
            yCenter = yUp + ySizeShape / 2;
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
    }
}
