using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext DB = new DataClasses1DataContext();
        BindingList<msproduk> lproduk = new BindingList<msproduk>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "No";
            dataGridView1.Columns[0].HeaderText = "Nama";
            dataGridView1.Columns[0].HeaderText = "Kelas";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = DB.msproduks.ToList();
            q = q.Where(x => x.price > 300000).ToList();
            dataGridView1.DataSource = q;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            //DB.headerdeliveries.Sum(obj => obj.detaildeliveries.Count());
            var q = DB.msproduks;
            q.Where(x => x.price > 300000);
            dataGridView1.DataSource = q;

            //dataGridView1.DataSource = lproduk;
            //dataGridView1.Rows.Add("1","test","test");
            //int a = dataGridView1.Rows.Add("2", "cba", "coba");
            //MessageBox.Show(a.ToString());
        }
    }
}
