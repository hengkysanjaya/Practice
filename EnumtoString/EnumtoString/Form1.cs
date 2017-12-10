using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumtoString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum data { red = 1,pink = 2 };
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 2; i++)
            {
                MessageBox.Show(((data)i).ToString());
            }
        }
    }
}
