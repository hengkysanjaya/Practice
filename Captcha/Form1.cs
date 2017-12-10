using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Bitmap b = new Bitmap(15,15);
            Graphics g = Graphics.FromImage(b);

            //g.DrawString("H", new Font("Arial", 12), Brushes.Black, 0, 0);

            g.TranslateTransform(7.5f, 7.5f);
            g.RotateTransform(45);
            g.TranslateTransform(-7.5f, -7.5f);
            g.DrawString("H", new Font("Arial", 12), Brushes.Black, 0, 0);
         
            e.Graphics.DrawImage(b, 10, 10);
            
            //g.TranslateTransform(7.5f, 7.5f);
            //g.RotateTransform(45);
            //g.TranslateTransform(-7.5f, -7.5f);
            Bitmap b2 = new Bitmap(15, 15);
            Graphics g2 = Graphics.FromImage(b2);
            g2.DrawString("E", new Font("Arial", 12), Brushes.Black, 0, 0);
            e.Graphics.DrawImage(b2, 20, 20);
        }

        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
    }
}
