using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ini;

namespace Shapes
{
    public class Decision : Shape, IBlock
    //элемент блок-схемы - неполное условие
    {
		#region Атрибуты
		public SolidBrush brush = new SolidBrush(Color.FromArgb(240, 250, 130));

        // наличие ветвлений справа/слева
        public bool isBranchLeft { get; set; } = false;
        public bool isBranchRight { get; set; } = true;
        public bool isBranchBody { get; set; } = false;

        public List<IBlock> blocksBody = new List<IBlock> { }; // блоки, входящие в тело если
		#endregion

		#region Конструктор
		public Decision(string _text) : base(_text)
        {
        }
        #endregion

        #region ini
        public void SetColor()
        {
            FileIni ini = new FileIni();
            int[] colors = ini["ColorDecision"].Split(',').Select(x => int.Parse(x)).ToArray();
            brush = new SolidBrush(Color.FromArgb(colors[0], colors[1], colors[2]));
        }
        #endregion

        #region Методы
        private int GetYDownBody(List<IBlock> blocks)
        {
            if (blocks.Count != 0)
            {
                IBlock lastBlock = GetLast(blocks);
                if (lastBlock is Process || lastBlock is Data)
                {
                    if (lastBlock.blocksPreparation.Count > 0 && blocks.Contains(GetLast(lastBlock.blocksPreparation)))
                        return this.yDown + this.shiftDown - this.yDistance;
                    if (lastBlock.blocksDecisionLoop.Count > 0 && blocks.Contains(GetLast(lastBlock.blocksDecisionLoop)))
                        return this.yDown + this.shiftDown - this.yDistance;
                    if (lastBlock.blocksDecision.Count > 0 && blocks.Contains(GetLast(lastBlock.blocksDecision)))
                        return this.yDown + this.shiftDown - this.yDistance;
                    if (lastBlock.blocksDecisionFullThen.Count > 0 && blocks.Contains(GetLast(lastBlock.blocksDecisionFullThen)))
                        return this.yDown + this.shiftDown - this.yDistance; 
                    if (lastBlock.blocksDecisionFullElse.Count > 0 && blocks.Contains(GetLast(lastBlock.blocksDecisionFullElse)))
                        return this.yDown + this.shiftDown - this.yDistance;
                    return lastBlock.yDown;
                }
            }
            return this.yDown + this.shiftDown - this.yDistance;
        }

        public void SetConnectorsPosition()
        {
            connectorsPoints.Add(new Point[]
            {
                new Point(xCenter, yDown),
                new Point(xCenter, yDown + yDistance)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xRight, yCenter),
                new Point(xRight + shiftRight, yCenter)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xRight + shiftRight, yCenter),
                new Point(xRight + shiftRight, yDown + shiftDown - yDistance) // ?
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xRight + shiftRight, yDown + shiftDown - yDistance), // ?
                new Point(xCenter, yDown + shiftDown - yDistance)
            });
            connectorsPoints.Add(new Point[]
            {
                new Point(xCenter, yDown + shiftDown - yDistance),
                new Point(xCenter, yDown + shiftDown)
            });

            connectorsPoints.Add(new Point[]
            {
                new Point(xCenter, GetYDownBody(blocksBody)),
                new Point(xCenter, yDown + shiftDown - yDistance)
            });
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
        #endregion
    }
}
