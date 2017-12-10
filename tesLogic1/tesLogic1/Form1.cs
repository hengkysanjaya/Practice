using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tesLogic1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            int founded = 0;
            char foundedchar = ' ';

            List<data> listdata = new List<data>()
            {
                new data() {founded = 0,foundedchar = ' ' }
            };

            foreach (var chr1 in text)
            {
                int found = 0;
                foreach (var chr2 in text)
                {
                    if (chr1 == chr2)
                    {
                        found += 1;
                    }
                }
                if (listdata.Where(x => x.foundedchar == chr1).Count() == 0)
                {
                    listdata.Add(new data() { foundedchar = chr1, founded = found });
                }
            }

            var q = listdata.Select(x => new
            {
                x.foundedchar,
                x.founded
            }).Where(x => x.founded == listdata.Max(y => y.founded));

            foreach (var a in q)
            {
                MessageBox.Show(a.foundedchar.ToString());
            }
        }

        class data
        {
            public int founded { get; set; }
            public char foundedchar { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Numbers = new List<string>()
            {
                "Zero",
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine"
            };

            string result = "";
            foreach(var chr in textBox2.Text)
            {
                int index = int.Parse(chr.ToString());
                result += Numbers[index];
            }
            MessageBox.Show(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Any(char.IsLower))
            {
                MessageBox.Show(textBox3.Text.ToUpper());
            }else
            {
                MessageBox.Show(textBox3.Text.ToLower());
            }
        }
    }
}
