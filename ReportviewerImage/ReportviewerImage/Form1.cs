using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReportviewerImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileInfo fi = new FileInfo(Application.StartupPath + "\\flag_argentina.png");
            //pictureBox1.Image = Image.FromFile(fi.Name);

            //this.reportViewer1.LocalReport.EnableExternalImages = true;
            //ReportParameter gambar = new ReportParameter("myPicture", fi.Name);
            //this.reportViewer1.LocalReport.EnableExternalImages = true;
            //this.reportViewer1.LocalReport.SetParameters(gambar);
            testing t = new testing();
            t.Path = Application.StartupPath + "\\flag_argentina.png";
            testingBindingSource.DataSource = t;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.RefreshReport();
        }
    }
    class testing
    {
        public string Path { get; set; }
    }
}
