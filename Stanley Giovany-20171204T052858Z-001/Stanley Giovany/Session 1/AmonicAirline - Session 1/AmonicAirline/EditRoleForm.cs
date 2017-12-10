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
    public partial class EditRoleForm : Form
    {
        session1Entities entities = new session1Entities();
        User User;

        public EditRoleForm(User user)
        {
            InitializeComponent();

            User = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = entities.Users
                .Where(x => x.ID == User.ID)
                .FirstOrDefault();

            var selectedRole = this.Controls.Cast<Control>()
                .Where(x => x.GetType() == typeof(RadioButton))
                .Cast<RadioButton>()
                .Where(x => x.Checked)
                .FirstOrDefault();

            int roleid = Int32.Parse(selectedRole.Tag.ToString());

            user.RoleID = roleid;
            entities.SaveChanges();

            DialogResult = DialogResult.OK;
        }

        private void EditRoleForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = User.Email;
            textBox2.Text = User.FirstName;
            textBox3.Text = User.LastName;

            var offices = entities.Offices.ToList();
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = offices;

            comboBox1.SelectedValue = User.OfficeID;

            if(User.RoleID == 1)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }
    }
}
