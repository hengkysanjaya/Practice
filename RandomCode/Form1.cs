using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string text = "abcdefghijklmnopqrstuvwxyz";
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            string kode = "";
            for (int i = 0; i < 4; i++)
            {
                kode += rand.Next(0, 10).ToString();
            }

            for (int i = 0; i < 4; i++)
            {
                kode += text[rand.Next(0, text.Length)].ToString();
            }
            StringBuilder sb = new StringBuilder(kode);
            for(int i = 0; i < 8; i++)
            {
                int index = rand.Next(0, sb.Length);
                char temp = sb[i];
                sb[i] = sb[index];
                sb[index] = temp;
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
