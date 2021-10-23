using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
    public class Process : Shape, IBlock
    // элемент блок-схемы - процесс
    {
        public SolidBrush brush = new SolidBrush(Color.Aqua);
        string text;
        int xLeft;
        int xRight;
        int yUp;
        int yDown;
        int xCenter;
        int yCenter;

        public Process(string _text)
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
            xCenter = xLeft + xRight / 2;
            yCenter = yUp + yDown / 2;
        }

        public void DrawShape(Graphics graphic)
        // отрисовать фигуру
        {
            Rectangle rect = new Rectangle(xLeft, yUp, xSizeShape, ySizeShape);
            graphic.FillRectangle(brush, rect);
            graphic.DrawRectangle(penMain, rect);
        }

        public void DrawText(Graphics graphic)
        // отрисовать текст
        {
            SetStringFormatCenter();
            graphic.DrawString(text, fontMain, brushText, new RectangleF(xLeft, yUp, xSizeShape, ySizeShape), stringFormatMain);
        }
    }

}
