using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubReport_Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Detail> listDetail = new List<Detail>();
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Header> listHeader = new List<Header>()
            {
                new Header() { IdTransaction = 1},
                new Header() { IdTransaction = 2},
                new Header() { IdTransaction = 3},
                new Header() { IdTransaction = 4},
            };

            listDetail.AddRange(new List<Detail>()
            {
                new Detail() { IdTransaction = 1,Nama = "AA",Kelas= "1"},
                new Detail() { IdTransaction = 1,Nama = "CC",Kelas= "2"},
                new Detail() { IdTransaction = 1,Nama = "BB",Kelas= "3"},
                new Detail() { IdTransaction = 2,Nama = "AA",Kelas= "1"},
                new Detail() { IdTransaction = 3,Nama = "AA",Kelas= "1"},
                new Detail() { IdTransaction = 2,Nama = "AA",Kelas= "1"},
            });
            HeaderBindingSource.DataSource = listHeader;
            this.reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            this.reportViewer1.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            var IdTransaction = e.Parameters[0].Values.FirstOrDefault().ToString();
            
            var q = listDetail.Where(x => x.IdTransaction.ToString() == IdTransaction);
            DetailBindingSource.DataSource = q.ToList();
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", DetailBindingSource));
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
