using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Terminator : Shape, IBlock
    //элемент блок-схемы - терминатор
    {
        public SolidBrush brush = new SolidBrush(Color.LightGray);
        bool isStart;

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = false;
        public bool isBranchBody { get; set; } = false;

        public Terminator(string _text, bool _isStart = false)
        {
            text = _text;
            ySizeShape = ySizeShape / 2; // по ГОСТу высота терминатора в 2 раза меньше других элементов
            isStart = _isStart;
        }

        public void SetPositionY(int _yUp)
        // установить позиции отрисовки
        {
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
    }
}
