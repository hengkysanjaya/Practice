using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class LoginForm : Form
    {
        session1Entities entities = new session1Entities();
        int failAttempts = 0;
        int countdown = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countdown--;
            label4.Text = $"You need to wait {countdown} seconds before you can login to the system again.";

            if(countdown == 0)
            {
                label4.Visible = false;
                button1.Enabled = true;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            string md5Password = Helper.HashStringToMD5(password);

            User user = entities.Users
                .Where(x => x.Email.Equals(username) && x.Password.Equals(md5Password))
                .FirstOrDefault();

            if (user == null)
            {
                MessageBox.Show("Your username / password is invalid!");
                failAttempts++;

                if(failAttempts == 3)
                {
                    failAttempts = 0;
                    countdown = 10;
                    label4.Visible = true;
                    button1.Enabled = false;
                    label4.Text = $"You need to wait {countdown} seconds before you can login to the system again.";
                    timer1.Start();
                }
            }
            else
            {
                if(!user.Active.Value)
                {
                    MessageBox.Show("Sorry, your account is inactive.");
                }
                else
                {
                    MainForm form = new MainForm(user);
                    form.Show();
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
