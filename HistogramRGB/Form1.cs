using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistogramRGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        public void Histogram(Bitmap image)
        {
            Bitmap d = new Bitmap(256, 1025);
            int[] hist = new int[255];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    int br = Convert.ToInt16(image.GetPixel(i, j).GetBrightness() * 50);
                    hist[br]++;
                }
            }

            for (int i = 0; i < 255; i++)
            {
                for (int j = 0; j < hist[i]; j++)
                {
                    d.SetPixel(i, j / 80, Color.Black);
                }
            }


            d.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox2.Image = d;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap w = new Bitmap(@"E:\з роб стола\HistogramRGB\w.jpg");
            pictureBox1.Image = w;
            Histogram(w);
        }
    }
}
