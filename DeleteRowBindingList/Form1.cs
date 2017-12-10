using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteRowBindingList
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext DB = new DataClasses1DataContext();
        BindingList<Product> blProduct;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var q = (Product)DB.Products.Where(x => x.ID.Equals(dataGridView1.CurrentRow.Cells[0].Value.ToString())).FirstOrDefault();
            //blProduct.Remove(q);
            DB.Products.DeleteOnSubmit(blProduct[0]);
            DB.SubmitChanges();
            loadHeader();
            MessageBox.Show("Updated");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadHeader();
        }

        private void loadHeader()
        {
            blProduct = new BindingList<Product>(DB.Products.ToList());
            dataGridView1.DataSource = blProduct;
        }
    }
}
