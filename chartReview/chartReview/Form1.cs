using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chartReview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<PesawatReport> list = new List<PesawatReport>();
        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<PesawatReport>()
            {
                new PesawatReport() { NamaPesawat = "AAA",Kapasitas = 100},
                new PesawatReport() { NamaPesawat = "BBB",Kapasitas = 200},
                new PesawatReport() { NamaPesawat = "CCC",Kapasitas = 300},
                new PesawatReport() { NamaPesawat = "DDD",Kapasitas = 400},
            };

            chart1.DataSource = list.ToList();
        }
    }
    class PesawatReport
    {
        public string NamaPesawat { get; set; }
        public int Kapasitas { get; set; }
    }
}
