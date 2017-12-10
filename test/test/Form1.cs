using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(h(poww(2,1000000000000000),"fruits"));
        }
        public string g(string str)
        {
            int i = 0;
            string newStr = "";
            while( i< str.Length - 1)
            {
                newStr = newStr + str[i + 1];
                i++;
            }
            return newStr;
        }
        public string f(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }
            else if (str.Length == 1)
            {
                return str;
            }
            else
                return f(g(str)) + str[0];
        }
        public string h(int n, string str)
        {
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                }else
                {
                    n = 3 * n + 1;
                }
                str = f(str);
            }
            return str;
        }
        public int poww(int x, int y)
        {
            if (y == 0)
            {
                return 1;
            }
            else
            {
                return x * poww(x, y - 1);
            }
        }
    }
}
