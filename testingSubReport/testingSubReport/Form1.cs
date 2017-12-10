using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testingSubReport
{
    public partial class Form1 : Form
    {
        List<SummaryReport> listReport;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HeaderReport hr = new HeaderReport()
            {
                Fieldwork = "test",
                SampleSize = "test"
            };
            HeaderReportBindingSource.DataSource = hr;

            List<SummaryReport> listReport = new List<SummaryReport>()
            {
                new SummaryReport() {Category = "Gender",Status = "Male",Total = 1 },
                new SummaryReport() {Category = "Gender",Status = "Female",Total = 1 },
            };
            SummaryReportBindingSource.DataSource = listReport.ToList();

            this.reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            this.reportViewer1.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", listReport));
        }
    }
    public class HeaderReport
    {
        public string Fieldwork { get; set; }
        public string SampleSize { get; set; }
    }

    public class SummaryReport
    {
        public string Category { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }
    }
}
