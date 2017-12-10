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
using System.Speech.Synthesis;

namespace CaptchaExample
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        string letter = "abcdefghijklmnopqrstuvwxyz";
        string Text;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateText();
            pictureBox1.Image = GenerateCaptcha(Text);
        }

        Random rand = new Random();
        public Image GenerateCaptcha(string word)
        {
            rand = new Random();

            Image img = new Bitmap(pictureBox1.Width / 2, pictureBox1.Height / 2);

            Graphics g = Graphics.FromImage(img);

            //SolidBrush sb = new SolidBrush(Color.FromArgb(Color.Black.ToArgb() ^ 0xffffff));

            Brush[] b =
            {
                Brushes.AliceBlue,
                Brushes.AntiqueWhite,
                Brushes.CadetBlue,
                Brushes.Coral,
                Brushes.Azure,
                Brushes.Beige,
                Brushes.DarkBlue,
                Brushes.DarkSeaGreen
            };
            
            g.FillRectangle(b[rand.Next(0,b.Length)], new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

            for (int i = 0; i < 25; i++)
            {
                int x = rand.Next(0, img.Width);
                int y = rand.Next(0, img.Height);
                g.FillEllipse(Brushes.White, new Rectangle(x, y, 4, 4));
            }
            
            //var hs = (HatchStyle[])Enum.GetValues(typeof(HatchStyle));

            //for (int i = 0; i < hs.Length; i++)
            //{
            //    using (HatchBrush hbr = new HatchBrush(hs[i],Color.White))
            //    {
            //        g.FillRectangle(hbr, new Rectangle(i * rand.Next(0, 3), rand.Next(4, 7), img.Width, img.Height));
            //    }
            //}

            g.DrawLine(Pens.Black, new Point(0, rand.Next(0,img.Height)), new Point(img.Width, rand.Next(0,img.Height)));
            for (int i = 0; i < word.Length; i++)
            {
                int rotate = rand.Next(-30, 30);
                
                Matrix m = new Matrix();
                m.RotateAt(rotate, new Point(i * 19 + 20, 20));
                g.Transform = m;
                g.DrawString(word[i].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, i * 19 + 20,20);
            }
            
            return img;
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateText();
            pictureBox1.Image = GenerateCaptcha(Text);
        }
        
        private void GenerateText()
        {
            Text = "";
            for (int i = 0; i < 6; i++)
            {
                int index = rand.Next(0, letter.Length);
                Text += letter[index].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            ss.Speak(string.Join(" ", Text.ToArray()));
        }
    }
}
