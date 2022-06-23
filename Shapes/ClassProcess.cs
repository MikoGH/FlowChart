using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ini;

namespace Shapes
{
    public class Process : Shape, IBlock
    // элемент блок-схемы - процесс
    {
		#region Атрибуты
		public SolidBrush brush = new SolidBrush(Color.FromArgb(180,230,250));

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = false;
        public bool isBranchBody { get; set; } = false;
		#endregion

		#region Конструктор
		public Process(string _text) : base(_text)
        {
            SetColor();
        }
        #endregion

        #region ini
        public void SetColor()
        {
            FileIni ini = new FileIni();
            int[] colors = ini["colorProcess"].Split(',').Select(x => int.Parse(x)).ToArray();
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
            Rectangle rect = new Rectangle(xLeft, yUp, xSizeShape, ySizeShape);
            graphic.FillRectangle(brush, rect);
            graphic.DrawRectangle(penMain, rect);
        }
        #endregion
    }

}
