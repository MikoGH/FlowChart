using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDiagram
{
    public class Shape
        // родительский класс для всех элементов блок-схемы
        // задает параметры, присущие всем элементам
    {
        // размеры фигур
        public int xSizeShape = 200;
        public int ySizeShape = 100;

        // кисти, шрифты
        public Pen penMain = new Pen(Color.Black, 2);
        public SolidBrush brushText = new SolidBrush(Color.Black);
        public Font fontMain = new Font("Courier New", 20);
    }


    public class Process : Shape
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
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            yUp = _yUp;
            yDown = yUp + ySizeShape;
            xCenter = xLeft + xRight / 2;
            yCenter = yUp + yDown / 2;
        }

        public void DrawShape(Graphics graphic)
        {
            Rectangle rect = new Rectangle(xLeft, yUp, xSizeShape, ySizeShape);
            graphic.FillRectangle(brush, rect);
            graphic.DrawRectangle(penMain, rect);
        }

        public void DrawText(Graphics graphic)
        {
            graphic.DrawString(text, fontMain, brushText, xLeft, yUp);
        }
    }
}
