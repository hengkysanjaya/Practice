using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace studywsc
{
    public partial class Login : core
    {
        int nFault = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!File.Exists(myPath))
            {
                File.Create(myPath);
            }
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

            if (textBox1.Text == "test@yahoo.com" && textBox2.Text == "test")
            {
                var q = GetList();
                var a = q.Where(x => x.Email == textBox1.Text && x.Reason == "").FirstOrDefault();

                coreLoginTime = DateTime.Now.ToString();
                coreEmail = textBox1.Text;

                this.Hide();

                if (a != null)
                {
                    new Transit(q, a.ID).Show();
                }
                else
                {
                    Main m = new Main();
                    m.Show();
                }
            }
            else
            {
                nFault++;
                MessageBox.Show("Username and password incorrect");
            }
        }

        int second = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            label3.Text = $"{second} seconds";
            if(second <= 0)
            {
                timer1.Stop();
                second = 10;
                nFault = 0;
                label3.Text = "";
            }
        }
    }
}
