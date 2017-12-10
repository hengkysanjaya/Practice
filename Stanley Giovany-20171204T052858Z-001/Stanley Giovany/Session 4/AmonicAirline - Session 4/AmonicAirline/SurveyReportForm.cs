using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class SurveyReportForm : Form
    {
        public SurveyReportForm()
        {
            InitializeComponent();
        }

        private void SurveyReportForm_Load(object sender, EventArgs e)
        {
            ResultSummary uc = new ResultSummary();
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        public static string GetAgeCategory(int age)
        {
            if (age >= 18 && age <= 24)
                return "18-24";
            else if (age >= 25 && age <= 39)
                return "25-39";
            else if (age >= 40 && age <= 59)
                return "40-59";
            else if (age >= 60)
                return "60+";
            else
                return "";
        }

        private void viewResultsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultSummary uc = new ResultSummary();
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void viewDetailedResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultDetail uc = new ResultDetail();
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
