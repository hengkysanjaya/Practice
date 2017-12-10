using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQueryableExample
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext DB = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            IQueryable<Product> q = DB.Products;

            MessageBox.Show("Before Where" + q.Count().ToString());
            q = q.Where(x => x.Price_Customer > 500000);
            MessageBox.Show("After Where" + q.Count().ToString());
        }
    }
}
