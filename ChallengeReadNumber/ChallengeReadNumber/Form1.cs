using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChallengeReadNumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = NumberToText(int.Parse(textBox1.Text));
            MessageBox.Show(a.ToLower());
        }
        private static string NumberToText(int n)
        {
            string result = "";
            if (n < 0)
            {
                result =  "Minus " + NumberToText(-n);
            }
            else if(n == 0)
            {
                result =  "";
            }
            else if (n < 10)
            {
                result =  new string[] { "Satu", "Dua", "Tiga", "Empat",
                                    "Lima", "Enam", "Tujuh", "Delapan",
                                    "Sembilan" }[n - 1];
            }
            else if (n == 10)
            {
                result = "Sepuluh";
            }
            else if (n < 20)
            {
                int a = int.Parse(n.ToString().Remove(0, 1));
                result =  NumberToText(a) + " Belas";
            }
            else if (n.ToString().Length == 2)
            {
                int a = int.Parse(n.ToString()[0].ToString());
                int b = int.Parse(n.ToString()[1].ToString());
                result =  NumberToText(a) + " Puluh " + NumberToText(b);
            }
            else if (n.ToString().Length == 3)
            {
                int ratusan = int.Parse(n.ToString()[0].ToString());
                int b = int.Parse(n.ToString().Remove(0, 1));
                result =  NumberToText(ratusan) + " Ratus " + NumberToText(b);
            }
            else if (n.ToString().Length == 4)
            {
                int ribuan = int.Parse(n.ToString()[0].ToString());
                int b = int.Parse(n.ToString().Remove(0, 1));
                result =  NumberToText(ribuan) + " Ribu " + NumberToText(b);
            }

            if(n.ToString().Length >=2)
            {   
                if (result.Contains("Satu "))
                {
                    result = result.Replace("Satu ", "Se");
                }
            }

            return   result;
        }
    }
}
