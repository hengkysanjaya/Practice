using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDFood_BakeryTry
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        BindingList<food> listFood = new BindingList<food>();
        food current;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv(false, false);
            Reload();
        }
        private void LoadDgv(bool statusWhere, bool statusCancel)
        {
            db = new DataClasses1DataContext();
            var q = db.foods.ToList();
            if (statusWhere)
            {
                string a = textBox1.Text.ToLower();
                q = q.Where(x => x.foodname.ToLower().Contains(a) || x.foodid.ToString().ToLower().Contains(a) || x.description.ToLower().Contains(a)).ToList();
            }

            listFood = new BindingList<food>(q.ToList());
            dataGridView1.DataSource = listFood;
        }
        private void Reload()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            textBox2.Text = (listFood.OrderByDescending(x => x.foodid).FirstOrDefault().foodid + 1).ToString();
            label3.Text = listFood.Count.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            food f = new food()
            {
                foodid = int.Parse(textBox2.Text),
                foodname = textBox3.Text,
                description = textBox4.Text,
                price = int.Parse(textBox5.Text)
            };
            db.foods.InsertOnSubmit(f);
            listFood.Add(f);
            Reload();
            MessageBox.Show("Berhasil");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDgv(true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.foods.DeleteOnSubmit(current);
            listFood.Remove(current);
            Reload();
            MessageBox.Show("Berhasil delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                current = listFood[e.RowIndex];
                textBox2.Text = current.foodid.ToString();
                textBox3.Text = current.foodname;
                textBox4.Text = current.description;
                textBox5.Text = current.price.ToString();
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            current.foodname = textBox3.Text;
            current.description = textBox4.Text;
            current.price = int.Parse(textBox5.Text);
            Reload();
            MessageBox.Show("Berhasil edit");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDgv(false, true);
            Reload();
        }
    }
}
