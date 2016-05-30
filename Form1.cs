using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Npgsql;
using Emgu.CV.UI;

namespace interpolation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int a = 3;
            Image<Gray, Byte> imgPr;
            string src = "interpolation.png";
            Image<Bgr, Byte> fimg;

            fimg = new Image<Bgr, byte>((Bitmap)Bitmap.FromFile(src));

            imgPr = fimg.InRange(new Bgr(0, 0, 0), new Bgr(100, 100, 100));

            Image<Bgr, Byte> zoom = new Image<Bgr, byte>(imgPr.Width * a, imgPr.Height * a);

            for (int i = 0; i < imgPr.Height * a; i++)
            {
                for (int j = 0; j < imgPr.Width * a; j++)
                {
                    if (i % a == 0)
                    {
                        if (j % a == 0)
                        {
                            zoom[i, j] = fimg[i / a, j / a];
                        }
                        else
                        {
                            Bgr color_m = fimg[i / a, j / a];
                            Bgr color_t;

                            if ((j / a) + 1 < fimg.Width)
                                color_t = fimg[i / a, (j / a) + 1];
                            else
                                color_t = color_m;
                            Bgr bgr = new Bgr((color_m.Blue + color_t.Blue) / 2, (color_m.Green + color_t.Green) / 2, (color_m.Red + color_t.Red) / 2);
                            zoom[i, j] = bgr;
                        }
                    }
                    else
                  
                    {
                        if (j % a == 0)
                       
                        {
                            Bgr color_l = fimg[i / a, j / a];
                            Bgr color_r;
                            if ((i / a) + 1 < fimg.Height)
                                color_r = fimg[Convert.ToInt32((i / a) + 1), j / a];
                            else
                                color_r = color_l;
                            Bgr bgr = new Bgr((color_l.Blue + color_r.Blue) / 2, (color_l.Green + color_r.Green) / 2, (color_l.Red + color_r.Red) / 2);
                            zoom[i, j] = bgr;
                        }
                        else

                     
                        {
                            Bgr color_l_t = fimg[i / a, j / a];
                            Bgr color_r_t;
                            if ((i / a) + 1 < fimg.Height)
                                color_r_t = fimg[(i / a) + 1, j / a];
                            else
                                color_r_t = color_l_t;
                            Bgr bgr_top = new Bgr((color_l_t.Blue + color_r_t.Blue) / 2, (color_l_t.Green + color_r_t.Green) / 2, (color_l_t.Red + color_r_t.Red) / 2);

                            Bgr bgr_bottom;
                            if ((j / a) + 1 < fimg.Width)
                            {
                                Bgr color_l_b = fimg[i / a, (j / a) + 1];
                                Bgr color_r_b;
                                if ((i / a) + 1 < fimg.Height)
                                    color_r_b = fimg[(i / a) + 1, (j / a) + 1];
                                else
                                    color_r_b = color_l_b;
                                bgr_bottom = new Bgr((color_l_b.Blue + color_r_b.Blue) / 2, (color_l_b.Green + color_r_b.Green) / 2, (color_l_b.Red + color_r_b.Red) / 2);
                            }
                            else
                                bgr_bottom = bgr_top;

                            Bgr bgr = new Bgr((bgr_top.Blue + bgr_bottom.Blue) / 2, (bgr_top.Green + bgr_bottom.Green) / 2, (bgr_top.Red + bgr_bottom.Red) / 2);

                            zoom[i, j] = bgr;
                        }
                    }
                }
            }


            new_img_box.Image = fimg;
            this.zoom_img_block.Image = zoom;

        }

    }
}