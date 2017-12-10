using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMICalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void MaleClick(object sender, EventArgs e)
        {
            panel3.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
        }

        private void FemaleClick(object sender, EventArgs e)
        {   
            panel2.BackColor = Color.White;
            panel3.BackColor = SystemColors.Control;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.White;
            panel2.BackColor = SystemColors.Control;
            label10.Text = "";

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Height = double.Parse(textBox1.Text) / 100;
            double Weight = double.Parse(textBox2.Text);
            double BMI = Weight / (Height * Height);
            label16.Text = BMI.ToString();
            if (BMI < 18.5)
            {
                panel9.Left = panel5.Left + (int)((panel5.Width * BMI) / 18.5) - 24;
                label10.Text = "Underweight";
                this.pictureBox3.Image = global::BMICalculator.Properties.Resources.bmi_underweight_icon;
            }
            else if (BMI >= 18.5 && BMI < 24.9)
            {
                panel9.Left = panel6.Left + (int)((panel6.Width * (BMI - 18.5)) / (24.9 - 18.5)) - 24;
                label10.Text = "Healthy";
                this.pictureBox3.Image = global::BMICalculator.Properties.Resources.bmi_healthy_icon;
            }
            else if (BMI >= 25 && BMI < 29.9)
            {
                panel9.Left = panel7.Left + (int)((panel7.Width * (BMI - 25)) / (29.9 - 25)) - 24;
                label10.Text = "Overweight";
                this.pictureBox3.Image = global::BMICalculator.Properties.Resources.bmi_overweight_icon;
            }
            else if (BMI >= 30)
            {
                panel9.Left = panel8.Left + (int)((panel8.Width * (70 - (70 - BMI)) / 70)) - 24;
                label10.Text = "Obese";
                this.pictureBox3.Image = global::BMICalculator.Properties.Resources.bmi_obese_icon;
            }
        }
    }
}
