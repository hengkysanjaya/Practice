using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportViewerImage_Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //List<MyReport> listReport = new List<MyReport>();
        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Screenshot (1).png";
            MyReport mr = new MyReport()
            {
                Imagepath = new Uri(path).AbsoluteUri,
                Title = "This is my title"
            };
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            MyReportBindingSource.DataSource = mr;
            this.reportViewer1.RefreshReport();
        }
    }

    class MyReport
    {
        public string Title { get; set; }
        public string Imagepath { get; set; }
    }
}
