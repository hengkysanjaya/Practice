using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnTupple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = testing(10, 10);
            MessageBox.Show(q.Item1.ToString());
            MessageBox.Show(q.Item2.ToString());
        }
        private Tuple<int,int> testing(int int1,int int2)
        {
            var tupple = new Tuple<int, int>(int1 + int2, int1 * int2);
            return tupple;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {               
            int a = 10 ^ 2;// 10 xor 2
            // true ^ false = true;


            // true ^ true = false;
            // false ^ false = false;
            MessageBox.Show(a.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string format = String.Format("{0:ddd, MMM dddd, yyyy}", dt);
            MessageBox.Show(format);
        }
    }
}
