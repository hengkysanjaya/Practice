using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgeCategory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<AgeCategoryData> list = new List<AgeCategoryData>();
        private void button1_Click(object sender, EventArgs e)
        {
            AgeCategoryData acd = new AgeCategoryData(textBox1.Text, textBox2.Text);
            var q = list.Where(x =>
                            (acd.Min >= x.Min && acd.Min <= x.Max) ||
                            (acd.Max >= x.Min && acd.Max <= x.Max) ||
                            (acd.Min <= x.Min && acd.Max >= x.Max)
                            ).Count();
            if(q > 0)
            {
                MessageBox.Show("Age Criteria already exists");
                return;
            }
            list.Add(acd);
            list = list.OrderBy(x => x.Min).ToList();
            listBox1.DataSource = list;
            listBox1.DisplayMember = "Display";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool move = false;
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"e.x : {e.X}\nbutton2left {button2.Left}\np.x {p.X}";
            if (move)
            {
                button2.Left = e.X + button2.Left - p.X;
                button2.Top = e.Y + button2.Top - p.Y;
            }
        }
        Point p;
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            label2.Text = $"p.x {p.X}";
            move = true;
        }
    }
    class AgeCategoryData
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string Display { get; set; }
        public AgeCategoryData(string min, string max)
        {
            if (min.ToLower() == "under")
            {
                Min = 0;
                Max = int.Parse(max) - 1;
                Display = $"Under {max}";
            }
            else if (min.ToLower() == "over")
            {
                Min = int.Parse(max) + 1;
                Max = int.MaxValue;
                Display = $"Over {max}";
            }
            else
            {
                int tempMax = int.Parse(max);
                int tempMin = int.Parse(min);
                if (tempMax < tempMin)
                {
                    throw new Exception("Max must be greater than Min");
                }
                else
                {
                    Min = tempMin;
                    Max = tempMax;
                    Display = $"{tempMin} to {tempMax}";
                }
                
            }
        }
    }
}
