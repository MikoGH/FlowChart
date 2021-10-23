﻿using System;
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
}
