using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlineExample
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void msfilmDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        BindingList<aa> bla = new BindingList<aa>();
        private void Form1_Load(object sender, EventArgs e)
        {
            bla = new BindingList<aa>(db.Users.Select(x => new aa
            {
                Nama = x.nama,
                NamaRole = x.Role.namarole,
                r = x.Role,
                u = x
            }).ToList());
            dataGridView1.DataSource = bla;

            var q = db.Users;

            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nama";
            comboBox1.DataSource = q;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var q = bla[e.RowIndex];
            
            q.Nama = "test";
            q.u.nama = "test";

            db.SubmitChanges();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
        
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var q = comboBox1.SelectedItem as User;
            MessageBox.Show(q.nama);
        }
    }
    class aa
    {
        public string Nama { get; set; }
        public string NamaRole { get; set; }
        public User u { get; set; }
        public Role r { get; set; }
    }

}
