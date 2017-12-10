using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollBarDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");
            dt.Columns.Add("Column4");
            dt.Columns.Add("Column5");
            dt.Columns.Add("Column6");
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 250;
            }
        }

        bool status = true;
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (status)
            {
                dataGridView1.FirstDisplayedScrollingColumnIndex = 4;
                status = false;
            }
            else if (!status)
            {
                dataGridView1.FirstDisplayedScrollingColumnIndex = 0;
                status = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
