using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class AdministratorMainScreen : UserControl
    {
        session1Entities entities = new session1Entities();
        List<User> dgvData;

        class OfficeData
        {
            public int ID { get; set; }
            public string Title { get; set; }
        }

        public AdministratorMainScreen()
        {
            InitializeComponent();
        }

        private void AdministratorMainScreen_Load(object sender, EventArgs e)
        {
            MainForm parent = this.ParentForm as MainForm;
            parent.adminCallback += Parent_adminCallback;

            List<OfficeData> offices = new List<OfficeData>()
            {
                new OfficeData() { ID = 0, Title = "All offices" }
            };

            offices.AddRange(entities.Offices
                .Select(x => new OfficeData
                {
                    ID = x.ID,
                    Title = x.Title
                }).ToList());

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Title";
            comboBox1.DataSource = offices;

            dgvData = entities.Users.ToList();

            RefreshDataGridView();
        }

        private void Parent_adminCallback()
        {
            entities = new session1Entities();
            dgvData = entities.Users.ToList();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dataGridView1.Columns.Clear();

            var users = dgvData
                .Select(x => new
                {
                    UserId = x.ID,
                    Name = x.FirstName,
                    LastName = x.LastName,
                    Age = Helper.GetAge(x.Birthdate.Value),
                    Role = x.Role.Title,
                    EmailAddress = x.Email,
                    Office = x.Office.Title,
                    Active = x.Active
                }).ToList();

            dataGridView1.DataSource = users;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["Active"].Visible = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool active = (bool)dataGridView1.Rows[i].Cells["Active"].Value;
                string role = dataGridView1.Rows[i].Cells["Role"].Value as string;

                if (!active)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (role.Equals("Administrator"))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }

            button2.Text = "Suspend / Unsuspend Account";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                OfficeData office = comboBox1.SelectedItem as OfficeData;

                if (office.ID == 0)
                {
                    dgvData = entities.Users.ToList();
                }
                else
                {
                    dgvData = entities.Users
                        .Where(x => x.OfficeID == office.ID)
                        .ToList();
                }

                RefreshDataGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Please select a user in datagridview!");
            }
            else
            {
                DataGridViewCell cell = dataGridView1.CurrentCell;
                int id = (int)dataGridView1.Rows[cell.RowIndex].Cells["UserId"].Value;

                User user = entities.Users
                    .Where(x => x.ID == id)
                    .FirstOrDefault();

                EditRoleForm form = new EditRoleForm(user);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    entities = new session1Entities();
                    dgvData = entities.Users.ToList();
                    RefreshDataGridView();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("Please select a user in datagridview!");
            }
            else
            {
                DataGridViewCell cell = dataGridView1.CurrentCell;
                int id = (int)dataGridView1.Rows[cell.RowIndex].Cells["UserId"].Value;

                User user = entities.Users
                    .Where(x => x.ID == id)
                    .FirstOrDefault();

                user.Active = !user.Active;
                entities.SaveChanges();

                dgvData = entities.Users.ToList();
                RefreshDataGridView();
            }
        }

        private void AdministratorMainScreen_DockChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                bool active = (bool)dataGridView1.Rows[e.RowIndex].Cells["Active"].Value;

                if(active)
                {
                    button2.Text = "Suspend Account";
                }
                else
                {
                    button2.Text = "Unsuspend Account";
                }
            }
        }
    }
}
