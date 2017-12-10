using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AmonicAirline
{
    public partial class ResultSummary : UserControl
    {
        session4Entities entities = new session4Entities();

        public ResultSummary()
        {
            InitializeComponent();
        }

        private void ResultSummary_Load(object sender, EventArgs e)
        {
            var submissions = entities.SurveySubmissions.ToList()
                .Select(x => new SurveyData
                {
                    Gender = x.Gender.Trim(),
                    CabinType = x.CabinType.Trim(),
                    DestinationAirport = x.ArrivalAirport.Trim(),
                    Age = x.Age.HasValue ? SurveyReportForm.GetAgeCategory(x.Age.Value) : ""
                })
                .ToList();

            var months = entities.SurveySubmissions
                .OrderBy(x => x.SubmissionYear)
                .ThenBy(x => x.SubmissionMonth)
                .ToList();

            string fieldWork = "";

            if(months.Count > 0)
            {
                DateTime start = new DateTime(months[0].SubmissionYear.Value, months[0].SubmissionMonth.Value, 1);
                DateTime end = new DateTime(months[months.Count - 1].SubmissionYear.Value, months[months.Count - 1].SubmissionMonth.Value, 1);

                fieldWork += start.ToString("MMMM yyyy");
                fieldWork += " - ";
                fieldWork += end.ToString("MMMM yyyy");
            }

            ReportParameter[] reportParams = new ReportParameter[]
            {
                new ReportParameter("Fieldwork", fieldWork)
            };

            ReportDataSource rds = new ReportDataSource("SurveyDataset", submissions);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(reportParams);
            
            reportViewer1.RefreshReport();
        }
    }
}
