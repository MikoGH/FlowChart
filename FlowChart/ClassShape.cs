using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowChart
{
    public class Shape
        // родительский класс для всех элементов блок-схемы
        // задает параметры, присущие всем элементам
    {
        // размеры фигур
        public int xSizeShape { get; set; } = 300;
        public int ySizeShape { get; set; } = 100;

        // дистанция между фигурами
        public int xDistance { get; set; } = 50;
        public int yDistance { get; set; } = 50;

        // сдвиги ветвлений слева и справа
        public int shiftLeft { get; set; } = 0;
        public int shiftRight { get; set; } = 300; // равен xSizeShape

        // кисти, шрифты, заливка
        public Pen penMain = new Pen(Color.Black, 3);
        public Font fontMain = new Font("Nunito", 20);
        public SolidBrush brushText = new SolidBrush(Color.Black);
        public StringFormat stringFormatMain = new StringFormat();

        public void SetStringFormatCenter()
        {
            stringFormatMain.Alignment = StringAlignment.Center;
            stringFormatMain.LineAlignment = StringAlignment.Center;
        }
    }
}
