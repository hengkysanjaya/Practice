using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testLogic2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Factorial(3).ToString());
        }

        private string Fibbonacci(int length)
        {
            return "";
        }

        private int Factorial(int n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
    }
}
