using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SharpImage
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();

            string pathName = "7777.jpg";
            Bitmap image = new Bitmap(pathName);
            pictureBox1.Image = image;
            A mask = new A(new int[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } });
            image = new Sharper().SharpIm(image, mask);
            pictureBox2.Image = image;
        }
    }
    class A
    {
        private int[,] array;
        public A(int[,] array)
        {
            this.array = array;
        }

        public int GetCell(int x, int y)
        {
            return this.array[x, y];
        }
    }
    class Sharper
    {
        private static int[,] pixelArray;

        private static int width;
        private static int height;

        public Bitmap SharpIm(Bitmap bitmap, A mask)
        {
            GetIntensities(bitmap);

            create(mask);

            delErrorInImage();

            return returnImage();
        }
        private void create(A mask)
        {
            int[,] imageWithMask = new int[width, height];

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    imageWithMask[x, y] = pixelArray[x - 1, y - 1] * mask.GetCell(0, 0) +
                                          pixelArray[x, y - 1] * mask.GetCell(1, 0) +
                                          pixelArray[x + 1, y - 1] * mask.GetCell(2, 0) +
                                          pixelArray[x - 1, y] * mask.GetCell(0, 1) +
                                          pixelArray[x, y] * mask.GetCell(1, 1) +
                                          pixelArray[x + 1, y] * mask.GetCell(2, 1) +
                                          pixelArray[x - 1, y + 1] * mask.GetCell(0, 2) +
                                          pixelArray[x, y + 1] * mask.GetCell(1, 2) +
                                          pixelArray[x + 1, y + 1] * mask.GetCell(2, 2);
                }
            }


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixelArray[x, y] -= imageWithMask[x, y];
                }
            }
        }


     
      
        private void delErrorInImage()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (pixelArray[x, y] < 0)
                    {
                        pixelArray[x, y] = 0;
                    }

                    if (pixelArray[x, y] > 255)
                    {
                        pixelArray[x, y] = 255;
                    }
                }
            }
        }
        private void GetIntensities(Bitmap bitmap)
        {
            const double r_c = 0.3;
            const double g_c = 0.59;
            const double b_c = 0.11;
            pixelArray = new int[bitmap.Width + 4, bitmap.Height + 4];

            width = pixelArray.GetLength(0);
            height = pixelArray.GetLength(1);

            for (int x = 2; x < width - 2; x++)
            {
                for (int y = 2; y < height - 2; y++)
                {
                    pixelArray[x, y] = (int)(r_c * bitmap.GetPixel(x - 2, y - 2).R +
                                             g_c * bitmap.GetPixel(x - 2, y - 2).G +
                                             b_c * bitmap.GetPixel(x - 2, y - 2).B);
                }
            }
        }


        private Bitmap returnImage()
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int color = pixelArray[x, y];

                    bitmap.SetPixel(x, y, Color.FromArgb(color, color, color));
                }
            }

            return bitmap;
        }
    }
    
}
