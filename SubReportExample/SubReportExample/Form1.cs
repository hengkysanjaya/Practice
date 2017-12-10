using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubReportExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Header> listHeader = new List<Header>();
            listHeader.AddRange(new List<Header>()
            {
                new Header() { IdTransaction = 1 },
                new Header() { IdTransaction = 2 }
            });

            //MessageBox.Show(listHeader.Count().ToString());
            HeaderBindingSource.DataSource = listHeader.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
    class Header
    {
        public int IdTransaction { get; set; }
        
    }
    class Detail
    {
        public int IdTransaction { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
    }
}
