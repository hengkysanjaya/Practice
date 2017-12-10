using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private String getAgeRange(int age)
        {
            if (age >= 20 && age <= 39)
                return "20-39";
            else if (age >= 40 && age <= 59)
                return "40-59";
            else if (age >= 60)
                return "60+";
            else
                return "16-20";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            DataTable dt = new DataTable();

            dt.Columns.Add("SurveyCategory",typeof(string));
            dt.Columns.Add("AnswerCategoryName", typeof(string));
            dt.Columns.Add("TotalSurvey", typeof(string));
            dt.Columns.Add("GenderName", typeof(string));
            dt.Columns.Add("TotalGender", typeof(string));
            dt.Columns.Add("AgeRange", typeof(string));
            dt.Columns.Add("TotalAgeRange", typeof(string));
            dt.Columns.Add("CabinTypeName", typeof(string));
            dt.Columns.Add("TotalCabinTypeName", typeof(string));
            dt.Columns.Add("AirportCode", typeof(string));
            dt.Columns.Add("TotalAirport", typeof(string));
            
            //cek stored procedure ya
            var x = db.getData();

            foreach(var s in x)
            {
                DataRow r = dt.NewRow();
                r["SurveyCategory"] = s.Question.ToString();
                r["AnswerCategoryName"] = s.Value.ToString();
                r["TotalSurvey"] = s.TotalSurvey.ToString();
                r["GenderName"] = s.Gender.ToString();
                r["TotalGender"] = s.TotalGender.ToString();
                r["AgeRange"] = s.AgeRange.ToString();
                r["TotalAgeRange"] = s.TotalAgeRange.ToString();
                r["CabinTypeName"] = s.CabinType.ToString();
                r["TotalCabinTypeName"] = s.TotalCabinType.ToString();
                r["AirportCode"] = s.AirportCode.ToString();
                r["TotalAirport"] = s.TotalAirport.ToString();

                dt.Rows.Add(r);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables[0]));
            reportViewer1.LocalReport.Refresh();

            this.reportViewer1.RefreshReport();
        }
    }
}
