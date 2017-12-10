using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OddEvenWithoutIf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] data = { "Genap", "Ganjil" };
        private void button1_Click(object sender, EventArgs e)
        {
            int angka = int.Parse(textBox1.Text);
            string a = data[angka % 2];
            MessageBox.Show(a);
        }
    }
}
