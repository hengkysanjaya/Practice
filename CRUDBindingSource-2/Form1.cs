using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBindingSource_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        BindingSource dgvSource = new BindingSource();
        private void Form1_Load(object sender, EventArgs e)
        {   
            dgvSource.DataSource = db.msfilms.Select(x=> new {
                title = x.title,
                obj = x
            });
            dataGridView1.DataSource = dgvSource;
            //dataGridView1.Columns["obj"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dgvSource.Current;
            
            var b = dataGridView1.CurrentRow.Cells[1].Value as msfilm;
            b.title = "test";
            dataGridView1.Refresh();

        }
    }
}
