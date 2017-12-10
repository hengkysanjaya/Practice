using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChallengeReadNumber_Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NumberToString(int.Parse(textBox1.Text)));
        }
        string[] data = { "", "puluh", "ratus", "ribu", "juta" };
        private string NumberToString(int n)
        {
            string result = "";
            string nstr = n.ToString();

            if (n < 0) result = "Minus " + NumberToString(-n);
            else if (n == 0) result = "";
            else if (n <= 10)
            {
                result = new string[] { "satu", "dua",
                            "tiga", "empat", "lima", "enam",
                            "tujuh", "delapan", "sembilan", "sepuluh" }[n - 1];
            }
            else if (n < 20)
            {
                int a = int.Parse(n.ToString()[1].ToString());
                result = NumberToString(a) + " belas";
            }
            else
            {
                // 120
                for (int i = 0; i < nstr.Length; i++)
                {
                    // i = 0  1  2
                    result += NumberToString(int.Parse(nstr[i].ToString()));
                    if (i != nstr.Length - 1)
                    {
                        result += " " + data[nstr.Length - (i + 1)] + " ";
                    }
                }
            }

            
            if (result.Length >= 2)
            {
                if (result.Contains("satu "))
                {
                    result = result.Replace("satu ", "se");
                }
            }
            return result;
        }
    }
}
