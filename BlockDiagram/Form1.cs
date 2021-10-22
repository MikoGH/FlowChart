using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagram
{
	public partial class FormMain : Form
	{

        Bitmap targetBitmap;

        public FormMain()
		{
			InitializeComponent();
		}

		private void btnCreateBD_Click(object sender, EventArgs e)
		{
            targetBitmap = new Bitmap(400, 400);
            using (Bitmap sourceBitmap = new Bitmap(100, 100))
            {
                using (Graphics graphic = Graphics.FromImage(targetBitmap))
                {
                    graphic.DrawImage(sourceBitmap, new Rectangle(0, 0, 200, 200));
                    graphic.DrawLine(new Pen(Color.Black, 2), 100, 100, 200, 200);
                    graphic.DrawString("abc123", new Font("Courier New", 20), new SolidBrush(Color.Black), 120, 100);
                }
            }

            if (pictureBox.Image != null) pictureBox.Image.Dispose();
			pictureBox.Image = targetBitmap;

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
            targetBitmap.Save("save01.jpeg");
        }
	}
	public class Shape
    {
        public Shape()
        {

        }
    }
}
