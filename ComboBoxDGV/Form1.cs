using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxDGV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[1].HeaderText = "Nama";
            dataGridView1.Columns[2].HeaderText = "DOBirth";
            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.HeaderText = "Kelas";
            comboColumn.Items.Add("1A");
            comboColumn.Items.Add("1B");
            comboColumn.Items.Add("1C");
            comboColumn.Items.Add("1D");
            comboColumn.Items.Add("1E");
            dataGridView1.Columns.Add(comboColumn);

            dataGridView1.Rows.Add("1", "test", "11");
            dataGridView1.Rows.Add("1", "test", "11");
            dataGridView1.Rows.Add("1", "test", "11");
            dataGridView1.Rows.Add("1", "test", "11");
            dataGridView1.Rows.Add("1", "test", "11");
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                dataGridView1.BeginEdit(true);
                ComboBox c = (ComboBox)dataGridView1.EditingControl;
                c.DroppedDown = true;
            }
        }
    }
}
