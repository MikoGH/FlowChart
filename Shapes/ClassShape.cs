using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ini;

namespace Shapes
{
    public class Shape
        // родительский класс для всех элементов блок-схемы
        // задает параметры, присущие всем элементам
    {
		#region Атрибуты
		// размеры фигур
		public int xSizeShape { get; set; } = 200;
		public int ySizeShape { get; set; } = 80;

        // дистанция между фигурами
        public int xDistance { get; set; } = 50;
        public int yDistance { get; set; } = 50;

        // сдвиги ветвлений слева и справа
        public int shiftLeft { get; set; } = 0;
        public int shiftRight { get; set; } = 0;
        public int shiftDown { get; set; } = 0;

        // блоки ветвлений, в теле которых находится данный блок
        public List<IBlock> blocksDecision { get; set; } = new List<IBlock> { }; // блоки неполного условия, в которых находится данный
        public List<IBlock> blocksDecisionFullThen { get; set; } = new List<IBlock> { }; // блоки полного условия, в теле then которых находится данный
        public List<IBlock> blocksDecisionFullElse { get; set; } = new List<IBlock> { }; // блоки полного условия, в теле else которых находится данный
        public List<IBlock> blocksDecisionLoop { get; set; } = new List<IBlock> { }; // блоки цикла while, в которых находится данный
        public List<IBlock> blocksPreparation { get; set; } = new List<IBlock> { }; // блоки цикла for, в которых находится данный

        // точки начала и конца линий связи блоков
        public List<Point[]> connectorsPoints = new List<Point[]> { };

        // длины проекций стрелок на оси координат
        // здесь были внесены правки
        public int longProj { get; set; } = 10;
        public int shortProj { get; set; } = 5;

        // кисти, шрифты, заливка
        public Pen penMain = new Pen(Color.Black, 3);
        public Font fontMain = new Font("Nunito", 16);
        public SolidBrush brushText = new SolidBrush(Color.Black);
        public StringFormat stringFormatMain = new StringFormat();

        public string text;
        public int xLeft { get; set; }
        public int xRight { get; set; }
        public int yUp { get; set; }
        public int yDown { get; set; }
        public int xCenter { get; set; }
        public int yCenter { get; set; }
		#endregion

		#region Конструктор
		public Shape(string _text)
		{
            text = _text;
            SetSize();
		}
		#endregion

		#region ini
		public void SetSize()
        {
            FileIni ini = new FileIni();
            xSizeShape = int.Parse(ini["xSizeShape"]);
            ySizeShape = int.Parse(ini["ySizeShape"]);
            xDistance = int.Parse(ini["xDistance"]);
            yDistance = int.Parse(ini["yDistance"]);
        }
		#endregion

		#region Методы
		public static IBlock GetLast(List<IBlock> lst)
        // возвращает последний объект из заданного списка
        {
            return lst[lst.Count - 1];
        }

        public virtual void SetPositionX(int _xLeft)
        // установить позиции отрисовки
        {
            xLeft = _xLeft;
            xRight = xLeft + xSizeShape;
            xCenter = xLeft + xSizeShape / 2;
        }

        public virtual void SetPositionY(int _yUp)
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
				if (connector[0].X > connector[1].X)
				{
                    graphic.DrawLine(penMain, connector[1], new Point(connector[1].X + longProj, connector[1].Y - shortProj));
                    graphic.DrawLine(penMain, connector[1], new Point(connector[1].X + longProj, connector[1].Y + shortProj));
                }
                if (connector[0].Y > connector[1].Y)
				{
					graphic.DrawLine(penMain, connector[1], new Point(connector[1].X + shortProj, connector[1].Y + longProj));
					graphic.DrawLine(penMain, connector[1], new Point(connector[1].X - shortProj, connector[1].Y + longProj));
				}
			}
        }
        #endregion
    }
}
