using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
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
        bool isStart;

        List<Point[]> connectorsPoints = new List<Point[]> { };

        public Terminator(string _text, bool _isStart = false)
        {
            text = _text;
            ySizeShape = ySizeShape / 2; // по ГОСТу высота терминатора в 2 раза меньше других элементов
            isStart = _isStart;
        }

        public void SetPosition(int _xLeft, int _yUp)
        // установить позиции отрисовки
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            xCenter = xLeft + xSizeShape / 2;

			if (isStart)
			{
                yUp = _yUp + ySizeShape;
                yDown = yUp + ySizeShape;
                yCenter = yUp + ySizeShape / 2;
            }
			else
			{
                yUp = _yUp;
                yDown = yUp + ySizeShape;
                yCenter = yUp + ySizeShape / 2;
            }
            
        }

        public void SetConnectorsPosition()
        {
			if (isStart)
            {
                connectorsPoints.Add(new Point[]
                    {
                    new Point(xCenter, yDown),
                    new Point(xCenter, yDown + yDistance)
                    });
            }
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

        public void DrawConnectors(Graphics graphic)
        {
            foreach (Point[] connector in connectorsPoints)
            {
                graphic.DrawLine(penMain, connector[0], connector[1]);
            }
        }
    }
}
