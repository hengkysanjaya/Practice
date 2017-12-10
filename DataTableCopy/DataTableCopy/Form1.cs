using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTableCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        DataTable dt = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("display");

            var q = db.Products.Select(x => new
            {
                display = x.Name,
                value = x.ID
            });

            foreach(var a in q)
            {
                dt.Rows.Add(a.value, a.display);
            }

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "value";
            comboBox1.DisplayMember = "display";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtCopy = new DataTable();
            dtCopy = dt.Copy();
            comboBox2.DataSource = dtCopy;
            comboBox2.ValueMember = "value";
            comboBox2.DisplayMember = "display";
        }
    }
}
