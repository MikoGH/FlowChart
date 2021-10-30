using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
{
    public class Process : Shape, IBlock
    // элемент блок-схемы - процесс
    {
        public SolidBrush brush = new SolidBrush(Color.FromArgb(180,230,250));
        string text;
        int xLeft;
        int xRight;
        int yUp;
        int yDown;
        int xCenter;
        int yCenter;

        List<Point[]> connectorsPoints = new List<Point[]> { };

        public Process(string _text)
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

        public void DrawConnectors(Graphics graphic)
        {
            foreach (Point[] connector in connectorsPoints)
            {
                graphic.DrawLine(penMain, connector[0], connector[1]);
            }
        }
    }

}
