using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class ImportCsvForm : Form
    {
        session4Entities entities = new session4Entities();
        
        public ImportCsvForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<SurveySubmission> submissions = new List<SurveySubmission>();
                    string path = openFileDialog1.FileName;

                    string[] lines = File.ReadAllLines(path);

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] contents = lines[i].Split(',');

                        string departure = contents[0];
                        string arrival = contents[1];
                        string ageString = contents[2];
                        string gender = contents[3].Equals("F") ? "Female" : contents[3].Equals("M") ? "Male" : contents[3];
                        string cabinType = contents[4];

                        int q1 = Int32.Parse(contents[5]);
                        int q2 = Int32.Parse(contents[6]);
                        int q3 = Int32.Parse(contents[7]);
                        int q4 = Int32.Parse(contents[8]);
                        int age = 0;

                        SurveySubmission submission = new SurveySubmission()
                        {
                            SurveyId = 1,
                            DepartureAirport = departure,
                            ArrivalAirport = arrival,
                            Gender = gender,
                            CabinType = cabinType,
                            SubmissionMonth = Int32.Parse(textBox1.Text.Trim()),
                            SubmissionYear = 2017,
                            SurveySubmissionDetails = new List<SurveySubmissionDetail>()
                        };

                        if(Int32.TryParse(ageString, out age))
                        {
                            submission.Age = age;
                        }

                        if (q1 != 0)
                        {
                            SurveySubmissionDetail detail = new SurveySubmissionDetail()
                            {
                                ChoiceId = q1,
                                QuestionId = 1
                            };

                            submission.SurveySubmissionDetails.Add(detail);
                        }

                        if (q2 != 0)
                        {
                            SurveySubmissionDetail detail = new SurveySubmissionDetail()
                            {
                                ChoiceId = q2,
                                QuestionId = 2
                            };

                            submission.SurveySubmissionDetails.Add(detail);
                        }

                        if (q3 != 0)
                        {
                            SurveySubmissionDetail detail = new SurveySubmissionDetail()
                            {
                                ChoiceId = q3,
                                QuestionId = 3
                            };

                            submission.SurveySubmissionDetails.Add(detail);
                        }

                        if (q4 != 0)
                        {
                            SurveySubmissionDetail detail = new SurveySubmissionDetail()
                            {
                                ChoiceId = q4,
                                QuestionId = 4
                            };

                            submission.SurveySubmissionDetails.Add(detail);
                        }

                        submissions.Add(submission);
                    }

                    entities.SurveySubmissions.AddRange(submissions);
                    entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
