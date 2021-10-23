using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
    
    public class Shape
        // родительский класс для всех элементов блок-схемы
        // задает параметры, присущие всем элементам
    {
        // размеры фигур
        public int xSizeShape = 300;
        public int ySizeShape = 100;

        // кисти, шрифты, заливка
        public Pen penMain = new Pen(Color.Black, 2);
        public SolidBrush brushText = new SolidBrush(Color.Black);
        public Font fontMain = new Font("Courier New", 20);
        public StringFormat stringFormatMain = new StringFormat();

        public void SetStringFormatCenter()
        {
            stringFormatMain.Alignment = StringAlignment.Center;
            stringFormatMain.LineAlignment = StringAlignment.Center;
        }
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


    public class Terminator : Shape
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


    public class Condition : Shape
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
