using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "Test aann data";
            string b = "aa";
            b = string.Copy(a);
            MessageBox.Show(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = "ab cd,ef gh,ij kl,mn op";
            char[] splitter = { ' ', ',' };
            
            string[] result = data.Split(splitter);
            foreach(var a in result)
            {
                MessageBox.Show(a.ToString());
            }
        }
    }
}
