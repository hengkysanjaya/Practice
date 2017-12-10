using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha_2
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string data = "abcdefghijklmnopqrstuvwxyz1234567890";
        
        public string GenerateText()
        {
            Text = "";
            Random rand = new Random();
            for (int i = 0; i < rand.Next(5,8); i++)
            {
                Text += data[rand.Next(0, data.Length)].ToString();
            }
            return Text;
        }

        string Text;
        private void button1_Click(object sender, EventArgs e)
        {
            Text = GenerateText();
            pictureBox1.Image = Captcha(Text);
        }

        private Image getImage(String text, int width, int height)
        {
            Image img = new Bitmap(text.Length * 20 + 45, 55);
            Random rand = new Random();
            int rotate;

            Color bgcolor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            SolidBrush sb = new SolidBrush(Color.FromArgb(bgcolor.ToArgb() ^ 0xffffff));
            Graphics graph = Graphics.FromImage(img);
            var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));

            for (int i = 0; i < hs.Length; i++)
            {
                using (HatchBrush hbr = new HatchBrush(hs[i], bgcolor))
                {
                    graph.FillRectangle(hbr, new Rectangle(i * rand.Next(0, 3), rand.Next(4, 7), width, height));
                }
            }

            FontFamily[] ff = new FontFamily[] {
                new FontFamily("Arial"),
                new FontFamily("Calibri"),
                new FontFamily("Times New Roman"),
            };

            Font font;

            for (int i = 0; i < text.Length; i++)
            {
                rotate = rand.Next(0, 30);
                Matrix mtr = new Matrix();
                mtr.RotateAt(rotate, new Point(i * 22 + 10, 10));
                graph.Transform = mtr;

                font = new Font(ff[rand.Next(0, ff.Length - 1)], rand.Next(14, 20), FontStyle.Bold);
                graph.DrawString(rand.Next(0, 1) == 1 ? Char.ToUpper(text[i]).ToString() : text[i].ToString(), font, sb, new Point(i * 22 + 20, 20));
                mtr.RotateAt(-rotate, new Point(i * 22 + 10, 10));
            }

            return img;
        }

        public Image Captcha(string word)
        {
            Random rand = new Random();

            Bitmap b = new Bitmap(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Color myColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            SolidBrush sb = new SolidBrush(Color.FromArgb(myColor.ToArgb() ^ 0xffffff));
            Graphics g = Graphics.FromImage(b);

            Font f = new Font("Open Sans", 14);

            var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));

            for (int i = 0; i < hs.Length; i++)
            {
                HatchBrush hb = new HatchBrush(hs[i], myColor);
                g.FillRectangle(hb, new Rectangle(i * rand.Next(0, 3), rand.Next(0, 3), b.Width, b.Height));
            }

            for (int i = 0; i < word.Length; i++)
            {
                int angle = rand.Next(-30, 30);
                Matrix m = new Matrix();
                m.RotateAt(angle, new Point(i * 15 + 10, 20));
                g.Transform = m;
                g.DrawString(word[i].ToString(), f, sb, new Point(i * 15 + 10, 20));
            }

            return b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ss.Speak(string.Join(" ",Text.ToArray()));
        }
    }
}
