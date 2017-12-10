using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudLinq_Try
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv();
        }
        private void LoadDgv()
        {
            var q = db.foods.ToList();
            list = new BindingList<food>(q);
            dataGridView1.DataSource = list;
        }

        BindingList<food> list = new BindingList<food>();
        food f;
        private void button1_Click(object sender, EventArgs e)
        {
            f = new food()
            {
                foodname = "test"
            };
            db.foods.InsertOnSubmit(f);
            list.Add(f);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.foods.DeleteOnSubmit(f);
            list.Remove(f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
            LoadDgv();
        }
    }
}
