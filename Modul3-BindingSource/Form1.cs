using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modul3_BindingSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        private void Form1_Load(object sender, EventArgs e)
        {   
            headerTransactionBindingSource.DataSource = db.HeaderTransactions.ToList();
            dataGridViewTextBoxColumn4.Visible = false;
            
        }

        private void headerTransactionDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            HeaderTransaction ht = (HeaderTransaction)headerTransactionBindingSource.Current;
            detailTransactionBindingSource.DataSource = db.DetailTransactions.Where(x => x.ID_Transaction.Equals(ht.ID)).ToList();
        }
    }
}
