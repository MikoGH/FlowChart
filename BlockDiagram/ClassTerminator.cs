using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
    public class Terminator : Shape, IBlock
    //элемент блок-схемы - терминатор
    {
        public SolidBrush brush = new SolidBrush(Color.LightGray);
        string text;
        int xLeft;
        int xRight;
        int yUp;
        int yDown;
        int xCenter;
        int yCenter;

        public Terminator(string _text)
        {
            text = _text;
            ySizeShape = ySizeShape / 2; // по ГОСТу высота терминатора в 2 раза меньше других элементов
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
            int ellipseDiameter = Math.Min(xSizeShape, ySizeShape);
            // левый полукруг
            graphic.FillEllipse(brush, new RectangleF(xLeft, yUp, ellipseDiameter, ellipseDiameter));
            graphic.DrawEllipse(penMain, new RectangleF(xLeft, yUp, ellipseDiameter, ellipseDiameter));
            // правый полукруг
            graphic.FillEllipse(brush, new RectangleF(xRight - ellipseDiameter, yUp, ellipseDiameter, ellipseDiameter));
            graphic.DrawEllipse(penMain, new RectangleF(xRight - ellipseDiameter, yUp, ellipseDiameter, ellipseDiameter));
            // центральный прямоугольник
            Rectangle rect = new Rectangle(xLeft + ellipseDiameter / 2, yUp, xSizeShape - ellipseDiameter, ySizeShape);
            graphic.FillRectangle(brush, rect);
            graphic.DrawLine(penMain, xLeft + ellipseDiameter / 2, yUp, xRight - ellipseDiameter / 2, yUp);
            graphic.DrawLine(penMain, xLeft + ellipseDiameter / 2, yDown, xRight - ellipseDiameter / 2, yDown);
        }

        public void DrawText(Graphics graphic)
        // отрисовать текст
        {
            SetStringFormatCenter();
            graphic.DrawString(text, fontMain, brushText, new RectangleF(xLeft, yUp, xSizeShape, ySizeShape), stringFormatMain);
        }
    }
}
