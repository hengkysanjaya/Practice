using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTextToList
{
    public partial class Login : core
    {
        int nFault = 0;
        int second = 10;

        public Login()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(nFault == 3)
            {
                if (!timer1.Enabled)
                {
                    MessageBox.Show("You have entered 3 times incorrect");
                    label3.Text = $"{second} seconds";
                    timer1.Start();
                    return;
                }
                else
                {
                    MessageBox.Show($"{second} left until you can attempt to login");
                    return;
                }
            }

            if (textBox1.Text == "hengkysanjaya204@yahoo.co.id" && textBox2.Text == "test")
            {
                var q = GetList();
                var a = q.Where(x => x.Email == textBox1.Text && x.Status == "").FirstOrDefault();
                coreEmail = textBox1.Text;

                if (a != null)
                {
                    new Form2(q).Show();
                }
                else
                {
                    this.Hide();
                    coreLogin = DateTime.Now;

                    if (new Form1().ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                    }
                }
            }
            else
            {
                nFault++;
                MessageBox.Show("Username and password incorrect");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            label3.Text = $"{second} seconds";
            if(second <= 0)
            {
                timer1.Stop();
                nFault = 0;
                second = 10;
                label3.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
