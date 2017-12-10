using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParameterReportViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Data> list = new List<Data>()
            {
                new Data() {Firstname = "A" ,Lastname = "A" },
                new Data() {Firstname = "B" ,Lastname = "B" },
                new Data() {Firstname = "C" ,Lastname = "C" },
                new Data() {Firstname = "D" ,Lastname = "D" },
                new Data() {Firstname = "E" ,Lastname = "E" },
                new Data() {Firstname = "F" ,Lastname = "F" },
                new Data() {Firstname = "G" ,Lastname = "G" },
            };
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Tanggal", DateTime.Now.ToString()));
            DataBindingSource.DataSource = list.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
    public class Data
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
