using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?=.*?[a-z])(?=.*?[A-Z])(?=.*\d)(?=.*?[#?!@$%^&*-]){6,}";
            Regex re = new Regex(pattern);
            if (re.IsMatch(textBox1.Text))
            {
                MessageBox.Show("True");
            }else
            {
                MessageBox.Show("False");
            }
        }
    }
}
