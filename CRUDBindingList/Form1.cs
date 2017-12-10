using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBindingList
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        BindingList<Product> blProduct;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            LoadDGV();
        }

        public void LoadDGV()
        {
            var q = db.Products.ToList();
            blProduct = new BindingList<Product>(q);
            dataGridView1.DataSource = blProduct;
            label1.Text = q.Count().ToString();

            textBox1.DataBindings.Add(new Binding("Text", blProduct, "ID"));

        }
        int index;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                index = dataGridView1.CurrentRow.Index;
                //textBox1.Text = blProduct[index].ID.ToString();
                textBox2.Text = blProduct[index].Name;
                textBox3.Text = blProduct[index].ID_Category.ToString();
                textBox4.Text = blProduct[index].Price_Customer.ToString();
                textBox5.Text = blProduct[index].Price_Sales.ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blProduct[index].ID = int.Parse(textBox1.Text);
            blProduct[index].Name = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
            LoadDGV();
            MessageBox.Show("Data Saved");
        }
    }
}
