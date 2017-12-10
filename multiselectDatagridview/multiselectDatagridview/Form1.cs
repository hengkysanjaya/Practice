using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiselectDatagridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns.Add("No", "No");
            dataGridView1.Columns.Add("Nama", "Nama");

            dataGridView1.Rows.Add("1", "Hengky");
            dataGridView1.Rows.Add("2", "Hengky Sanjaya");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = dataGridView1.SelectedRows;
            for (int i = 0; i < a.Count; i++)
            {
                MessageBox.Show(a[i].Cells[0].Value.ToString());
            }
        }
    }
}
