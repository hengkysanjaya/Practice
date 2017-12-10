using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp7Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Introduction(textBox1.Text));
        }
        private string Introduction(string name) => $"Hello everyone my name is {name}";

        private void button2_Click(object sender, EventArgs e)
        {
            //string Introduction(string name) = $"Hello this from local";

            int[] numbers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            foreach(int number in numbers)
            {

            }
        }
    }
}
