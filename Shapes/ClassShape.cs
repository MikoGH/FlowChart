using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Shape
        // родительский класс для всех элементов блок-схемы
        // задает параметры, присущие всем элементам
    {
        // размеры фигур
        public int xSizeShape { get; set; } = 200;
        public int ySizeShape { get; set; } = 80;

        // дистанция между фигурами
        public int xDistance { get; set; } = 50;
        public int yDistance { get; set; } = 50;

        // сдвиги ветвлений слева и справа
        public int shiftLeft { get; set; } = 0;
        public int shiftRight { get; set; } = 0;

        // блоки ветвлений, в теле которых находится данный блок
        public List<IBlock> blocksDecision { get; set; } = new List<IBlock> { }; // блоки неполного условия, в которых находится данный
        public List<IBlock> blocksDecisionFullThen { get; set; } = new List<IBlock> { }; // блоки полного условия, в теле then которых находится данный
        public List<IBlock> blocksDecisionFullElse { get; set; } = new List<IBlock> { }; // блоки полного условия, в теле else которых находится данный
        public List<IBlock> blocksDecisionLoop { get; set; } = new List<IBlock> { }; // блоки цикла while, в которых находится данный
        public List<IBlock> blocksPreparation { get; set; } = new List<IBlock> { }; // блоки цикла for, в которых находится данный

        // точки начала и конца линий связи блоков
        public List<Point[]> connectorsPoints = new List<Point[]> { };

        // кисти, шрифты, заливка
        public Pen penMain = new Pen(Color.Black, 3);
        public Font fontMain = new Font("Nunito", 20);
        public SolidBrush brushText = new SolidBrush(Color.Black);
        public StringFormat stringFormatMain = new StringFormat();

        public string text;
        public int xLeft { get; set; }
        public int xRight { get; set; }
        public int yUp { get; set; }
        public int yDown { get; set; }
        public int xCenter { get; set; }
        public int yCenter { get; set; }

        public void SetPositionX(int _xLeft)
        // установить позиции отрисовки
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            xCenter = xLeft + xSizeShape / 2;
        }

        public void SetPositionY(int _yUp)
        // установить позиции отрисовки
        {
            yUp = _yUp;
            yDown = yUp + ySizeShape;
            yCenter = yUp + ySizeShape / 2;
        }

        public void SetStringFormatCenter()
        // установить выравнивание текста по центру
        {
            stringFormatMain.Alignment = StringAlignment.Center;
            stringFormatMain.LineAlignment = StringAlignment.Center;
        }

        public void DrawText(Graphics graphic)
        // отрисовать текст
        {
            SetStringFormatCenter();
            graphic.DrawString(text, fontMain, brushText, new RectangleF(xLeft, yUp, xSizeShape, ySizeShape), stringFormatMain);
        }
        public void DrawConnectors(Graphics graphic)
        // отрисовать линии ветвлений
        {
            foreach (Point[] connector in connectorsPoints)
            {
                graphic.DrawLine(penMain, connector[0], connector[1]);
            }
        }
    }
}
