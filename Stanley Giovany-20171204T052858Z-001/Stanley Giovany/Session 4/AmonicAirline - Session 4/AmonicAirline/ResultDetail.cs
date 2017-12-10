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
    public partial class ResultDetail : UserControl
    {
        session4Entities entities = new session4Entities();
        bool formReady = false;

        class TimeFilterData
        {
            public int Month { get; set; }
            public int Year { get; set; }
            public string Display { get; set; }
        }

        class CategoryFilterData
        {
            public string Value { get; set; }
            public string Display { get; set; }
        }

        public ResultDetail()
        {
            InitializeComponent();
        }

        private void ResultDetail_Load(object sender, EventArgs e)
        {
            LoadFilter();
            GenerateReportDetailData();
            formReady = true;
        }

        private void LoadFilter()
        {
            var timeFilters = new List<TimeFilterData>()
            {
                new TimeFilterData { Month=0, Year=0, Display="No filter"}
            };

            var times = entities.SurveySubmissions.ToList()
                .GroupBy(x => new DateTime(x.SubmissionYear.Value, x.SubmissionMonth.Value, 1).ToString("MMMM yyyy"))
                .Select(x => new TimeFilterData
                {
                    Month = x.First().SubmissionMonth.Value,
                    Year = x.First().SubmissionYear.Value,
                    Display = x.Key
                })
                .Distinct()
                .ToList();

            timeFilters.AddRange(times);
            comboBox1.DisplayMember = "Display";
            comboBox1.DataSource = timeFilters;

            var genderFilters = new List<CategoryFilterData>()
            {
                new CategoryFilterData() { Value="", Display="All genders" },
                new CategoryFilterData() { Value="Male", Display="Male" },
                new CategoryFilterData() { Value="Female", Display="Female" }
            };

            var ageFilters = new List<CategoryFilterData>()
            {
                new CategoryFilterData() { Value="", Display="All ages" },
                new CategoryFilterData() { Value="18-24", Display="18-24" },
                new CategoryFilterData() { Value="25-39", Display="25-39" },
                new CategoryFilterData() { Value="40-59", Display="40-59" },
                new CategoryFilterData() { Value="60+", Display="60+" }
            };

            comboBox3.ValueMember = "Value";
            comboBox3.DisplayMember = "Display";
            comboBox3.DataSource = genderFilters;

            comboBox2.ValueMember = "Value";
            comboBox2.DisplayMember = "Display";
            comboBox2.DataSource = ageFilters;
        }

        private void GenerateReportDetailData()
        {
            TimeFilterData filter = comboBox1.SelectedItem as TimeFilterData;

            var submissionDetailData = entities.SurveySubmissionDetails.ToList();

            if(filter.Month != 0 && filter.Year != 0)
            {
                submissionDetailData = submissionDetailData
                    .Where(x => x.SurveySubmission.SubmissionYear == filter.Year && x.SurveySubmission.SubmissionMonth == filter.Month)
                    .ToList();
            }

            var submissionDetail = submissionDetailData
                .Select(x => new SurveyDetailData
                {
                    Question = x.Question.QuestionText,
                    Choice = x.Choice.ChoiceText,
                    Gender = x.SurveySubmission.Gender.Trim(),
                    CabinType = x.SurveySubmission.CabinType.Trim(),
                    DestinationAirport = x.SurveySubmission.ArrivalAirport.Trim(),
                    Age = x.SurveySubmission.Age.HasValue ? SurveyReportForm.GetAgeCategory(x.SurveySubmission.Age.Value) : "",
                    GenderValue = x.SurveySubmission.Gender.Trim().Equals("") ? 0 : 1,
                    CabinTypeValue = x.SurveySubmission.CabinType.Trim().Equals("") ? 0 : 1,
                    DestinationAirportValue = x.SurveySubmission.ArrivalAirport.Trim().Equals("") ? 0 : 1,
                    AgeValue = x.SurveySubmission.Age.HasValue ? 1 : 0
                })
                .ToList();
            

            if(!cbGender.Checked)
            {
                foreach (var detail in submissionDetail)
                {
                    detail.Gender = "";
                    detail.GenderValue = 0;
                }
            }
            else
            {
                CategoryFilterData category = comboBox3.SelectedItem as CategoryFilterData;

                if(!category.Value.Equals(""))
                {
                    foreach (var detail in submissionDetail)
                    {
                        if(!detail.Gender.Equals(category.Value))
                        {
                            detail.Gender = "";
                            detail.GenderValue = 0;
                        }
                    }
                }
            }

            if(!cbAge.Checked)
            {
                foreach (var detail in submissionDetail)
                {
                    detail.Age = "";
                    detail.AgeValue = 0;
                }
            }
            else
            {
                CategoryFilterData category = comboBox2.SelectedItem as CategoryFilterData;

                if(!category.Value.Equals(""))
                {
                    foreach (var detail in submissionDetail)
                    {
                        if (!detail.Age.Equals(category.Value))
                        {
                            detail.Age = "";
                            detail.AgeValue = 0;
                        }
                    }
                }
            }

            //submissionDetail.Clear();
            //submissionDetail = new List<SurveyDetailData>()
            //{
            //    new SurveyDetailData() { Question = "Pertanyaan pertama",Choice = "Good",
            //            Gender = "Male",Age = "18-24" ,CabinType = "Economy",DestinationAirport = "AUH"},

            //    new SurveyDetailData() { Question = "Pertanyaan pertama",Choice = "Good",
            //            Gender = "Male",Age = "25-30" ,CabinType = "Economy",DestinationAirport = "AUH"},

            //    new SurveyDetailData() { Question = "Pertanyaan pertama",Choice = "Good",
            //            Gender = "Male",Age = "25-30" ,CabinType = "Business",DestinationAirport = "AUH"},

            //    new SurveyDetailData() { Question = "Pertanyaan pertama",Choice = "Very Good",
            //            Gender = "Male",Age = "18-24" ,CabinType = "Business",DestinationAirport = "AUH"},

            //    new SurveyDetailData() { Question = "Pertanyaan pertama",Choice = "Very Good",
            //            Gender = "Male",Age = "25-30" ,CabinType = "Business",DestinationAirport = "AUH"},

            //    new SurveyDetailData() { Question = "Pertanyaan Kedua",Choice = "Very Good",
            //            Gender = "Male",Age = "25-30" ,CabinType = "Business",DestinationAirport = "AUH"},
            //};
            
            ReportDataSource rds = new ReportDataSource("SurveyDetailDataset", submissionDetail);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void cbGender_CheckedChanged(object sender, EventArgs e)
        {
            if(formReady)
                GenerateReportDetailData();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formReady)
                GenerateReportDetailData();
        }

        private void cbAge_CheckedChanged(object sender, EventArgs e)
        {
            if (formReady)
                GenerateReportDetailData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formReady)
                GenerateReportDetailData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formReady)
                GenerateReportDetailData();
        }
    }
}
