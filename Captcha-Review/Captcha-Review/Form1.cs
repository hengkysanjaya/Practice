using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha_Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string text = "abcde";
        Random rand;
        private Image GenerateCaptcha()
        {
            rand = new Random();
            Bitmap bmp = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(bmp);

            Color bgColor = Color.FromArgb(rand.Next(100, 150), rand.Next(0, 150), rand.Next(100, 255));
            Color foreColor = Color.FromArgb(rand.Next(0, 40), rand.Next(0, 40), rand.Next(0, 40));
            SolidBrush sb = new SolidBrush(Color.FromArgb(foreColor.ToArgb() ^ 0xfffff));
            

            var myFonts = new FontFamily[]
            {
                new FontFamily("Arial"),
                new FontFamily("Consolas"),
                new FontFamily("Constantia"),
                new FontFamily("Corbel"),
            };

            var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));
            for (int i = 0; i < hs.Length; i++)
            {
                using (HatchBrush hb = new HatchBrush(hs[i], bgColor))
                {
                    g.FillRectangle(hb, new Rectangle(i * rand.Next(0, 3), rand.Next(0, 3), bmp.Width, bmp.Height));
                }
            }


            for (int i = 0; i < text.Length; i++)
            {
                int angle = rand.Next(-30, 30);
                int fontIndex = rand.Next(0, myFonts.Length);
                Font currentFont = new Font(myFonts[fontIndex], 12);

                Matrix m = new Matrix();
                SizeF s = g.MeasureString(text[i].ToString(), currentFont);

                m.RotateAt(angle, new PointF(s.Width * i + 19, 19));
                g.Transform = m;
                g.DrawString(text[i].ToString(), currentFont, sb, new PointF(s.Width * i + 19, 19));
            }
            return bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image =  GenerateCaptcha();
        }
    }
}
