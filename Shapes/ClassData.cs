using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ini;

namespace Shapes
{
	public class Data : Shape, IBlock
    // элемент блок-схемы - ввод/вывод данных
    {
		#region Атрибуты
		public SolidBrush brush = new SolidBrush(Color.FromArgb(120, 230, 150));

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = false;
        public bool isBranchBody { get; set; } = false;
		#endregion

		#region Конструктор
		public Data(string _text) : base(_text)
        {
        }
        #endregion

        #region ini
        public void SetColor()
        {
            FileIni ini = new FileIni();
            int[] colors = ini["ColorData"].Split(',').Select(x => int.Parse(x)).ToArray();
            brush = new SolidBrush(Color.FromArgb(colors[0], colors[1], colors[2]));
        }
        #endregion

        #region Методы
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
            Point[] points =
            {
                new Point(xLeft+xSizeShape/5, yUp),
                new Point(xRight, yUp),
                new Point(xRight-xSizeShape/5, yDown),
                new Point(xLeft, yDown)
            };
            graphic.FillPolygon(brush, points);
            graphic.DrawPolygon(penMain, points);
        }
        #endregion
    }
}
