using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTableColumn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
             dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("Nama");
            dt.Columns.Add("Qty",Type.GetType("System.Int32"));
            dt.Columns.Add("Price",Type.GetType("System.Int32"));
            dt.Columns.Add("Subtotal", Type.GetType("System.Int32"), "Qty*Price");


            dt.Rows.Add("1", "test", 2, 10000);
            dt.Rows.Add("1", "test", 5, 15000);
            dt.Rows.Add("1", "test", 4, 25000);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N0";
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }
    }
}
