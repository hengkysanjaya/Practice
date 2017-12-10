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
    public partial class AddUserForm : Form
    {
        session1Entities entities = new session1Entities();

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string firstName = textBox2.Text.Trim();
            string lastName = textBox3.Text.Trim();
            DateTime birthDate = dateTimePicker1.Value;
            string password = textBox4.Text.Trim();

            if(email.Equals("") || firstName.Equals("") || lastName.Equals("") || password.Equals("") || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                Office office = comboBox1.SelectedItem as Office;

                User existing = entities.Users
                    .Where(x => x.Email.Equals(email))
                    .FirstOrDefault();

                if (existing != null)
                {
                    MessageBox.Show("Email used already!");
                }
                else
                {
                    User user = new User()
                    {
                        ID = Helper.GenerateUserId(),
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Birthdate = birthDate,
                        OfficeID = office.ID,
                        Active = true,
                        RoleID = 2,
                        Password = password
                    };

                    entities.Users.Add(user);
                    entities.SaveChanges();

                    MessageBox.Show("User added!");
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            var offices = entities.Offices.ToList();

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Title";
            comboBox1.DataSource = offices;
        }
    }
}
