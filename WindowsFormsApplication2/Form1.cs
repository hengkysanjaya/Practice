using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        module03_19Entities db = new module03_19Entities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            headerTransactionBindingSource.DataSource = db.HeaderTransactions.ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //headerTransactionBindingSource.MoveNext();
            headerTransactionBindingSource.Filter = "ID_Employee = 'E0059'";
            //headerTransactionBindingSource.DataSource = db.HeaderTransactions.Where(x => x.ID == 5).ToList();
            //headerTransactionBindingSource.SuspendBinding();

        }

        private void headerTransactionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            headerTransactionBindingSource.ResumeBinding();
        }
    }
}
