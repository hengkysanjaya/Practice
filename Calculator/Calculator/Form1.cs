using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double? total = null;
        double angka = 0;
        bool statusTotal = false;
        private void btn_click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Tag == "number")
            {
                if (statusTotal)
                {
                    textBox1.Text = "";
                    statusTotal = false;
                }

                textBox1.Text = textBox1.Text == "0" ? "" : textBox1.Text;
                textBox1.Text += btn.Text;
            }
            else if (btn.Tag == "operator")
            {
                angka = double.Parse(textBox1.Text);
                if (total == null)
                {
                    total = 1;
                }

                // MessageBox.Show(angka.ToString());
               

                if (btn.Text != "=")
                {
                    Operate(btn.Text);
                    label2.Text += textBox1.Text + " " + btn.Text;
                }
                else
                {
                    label2.Text = "";
                    Operate(lastOperator);
                }

                textBox1.Text = total.ToString();
                statusTotal = true;

                if(btn.Text == "=")
                {
                    total = 1;
                }
            }

        }

        string lastOperator = "";
        private void Operate(string text)
        {
            lastOperator = text;
            switch (text)
            {
                case "✖":
                    total *= angka;
                    break;
                case "➖":
                    total -= angka;
                    break;
                case "➗":
                    total /= angka;
                    break;
                case "+":
                    total += angka;
                    break;
                case "=":
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

    }
}
