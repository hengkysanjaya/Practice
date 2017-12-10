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
    public partial class MonitoringForm : Form
    {
        session1Entities entities = new session1Entities();
        SessionLog SessionLog;

        public MonitoringForm(SessionLog sessLog)
        {
            InitializeComponent();

            SessionLog = sessLog;
        }

        private void MonitoringForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"No logout detected for your last login on {SessionLog.LoginTime.ToString("MM/dd/yyyy")} at {SessionLog.LoginTime.ToString("HH:mm")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reason = richTextBox1.Text.Trim();
            var checkedRdb = this.Controls.Cast<Control>()
                .Where(x => x.GetType() == typeof(RadioButton))
                .Cast<RadioButton>()
                .Where(x => x.Checked)
                .FirstOrDefault();

            if(checkedRdb == null)
            {
                MessageBox.Show("Please select the crash category below!");
            }
            else if(reason.Equals(""))
            {
                MessageBox.Show("Please input the reason!");
            }
            else
            {
                CrashReport crashReport = new CrashReport()
                {
                    SessionLogID = SessionLog.SessionLogID,
                    CrashTypeID = Int32.Parse(checkedRdb.Tag.ToString()),
                    CrashDescription = reason
                };

                entities.CrashReports.Add(crashReport);
                entities.SaveChanges();

                DialogResult = DialogResult.OK;
            }
        }
    }
}
