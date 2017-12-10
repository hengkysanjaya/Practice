using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwitchExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 1;
            switch (n)
            {
                case 1: case 2:
                    MessageBox.Show("1 atau 2");
                    break;
                default:
                    MessageBox.Show("Unknown");
                    break;
            }
        }
    }
}
