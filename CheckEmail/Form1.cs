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

namespace CheckEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (!CheckEmail(textBox1.Text))
            {
                MessageBox.Show("Email Incorrect");
            }else
            {
                MessageBox.Show("Email Correct");
            }
        }
        public bool CheckEmail(string Email)
        {
            // test@yahoo.com
            string[] part1 = Email.Split('@');
            if(part1.Length!=2 || part1[0] == "" || part1[1] == "")
            {
                return false;
            }

            string[] part2 = part1[1].Split('.');
            if(part2.Length!=2 || part2[0] == "" || part2[1] == "")
            {
                return false;
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetRaceTime(7322));
        }
        public static string GetRaceTime(double tick)
        {
            var second = tick % 60;
            var minutes = (tick - second) / 60;
            var minute = minutes % 60;
            
            var hour = (minutes) / 60;

            return string.Format("{0}h {1:00}m {2:00}s", (int)hour, minute, second);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = String.Format("{0:.00}", 5.234);
            // result = 5.24
            MessageBox.Show(a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Environment.CurrentDirectory);
        }
    }
}
