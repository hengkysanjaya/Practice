using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class UserMainScreen : UserControl
    {
        session1Entities entities = new session1Entities();

        public UserMainScreen()
        {
            InitializeComponent();
        }

        private void UserMainScreen_Load(object sender, EventArgs e)
        {
            User loggedUser = MainForm.LoggedUser;

            User user = entities.Users.Where(x => x.ID == loggedUser.ID).FirstOrDefault();
            lblWelcome.Text = $"Hi {user.FirstName} {user.LastName}, Welcome to AMONIC Airlines.";

            SessionLog currentSession = MainForm.CurrentSession;
            DateTime lastMonth = DateTime.Now.AddDays(-30);
            var userLog = entities.SessionLogs
                .Where(x => x.UserID == user.ID && x.LoginTime >= lastMonth && x.SessionLogID != currentSession.SessionLogID)
                .OrderByDescending(x => x.LoginTime)
                .ToList();

            var dgvData = userLog.Select(x => new
            {
                Date = x.LoginTime.ToString("MM/dd/yyyy"),
                LoginTime = x.LoginTime.ToString("H:mm"),
                LogoutTime = x.LogoutTime.HasValue ? x.LogoutTime.Value.ToString("H:mm") : "**",
                TimeSpentOnSystem = x.LogoutTime.HasValue ? Helper.GetTimeDifference(x.LoginTime, x.LogoutTime.Value, @"hh\:mm") : "**",
                UnsuccessfulLogoutReason = !x.LogoutTime.HasValue && x.CrashReports.Count > 0 ? x.CrashReports.First().CrashDescription : ""
            }).ToList();

            dataGridView1.DataSource = dgvData;
            FillDgvColor();

            var loggedOutData = userLog.Where(x => x.LogoutTime.HasValue).ToList();
            DateTime before = new DateTime(1, 1, 1);
            DateTime after = new DateTime(1, 1, 1);

            foreach (var data in loggedOutData)
            {
                after = after + (data.LogoutTime.Value - data.LoginTime);
            }

            lblTimeSpent.Text = $"Time spent on system: {Helper.GetTimeDifference(before, after, @"hh\:mm\:ss")}";
            lblNumberCrash.Text = $"Number of crashes: {userLog.Where(x => !x.LogoutTime.HasValue).Count()}";
        }

        private void FillDgvColor()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string logoutTime = dataGridView1.Rows[i].Cells["LogoutTime"].Value as string;

                if (logoutTime.Equals("**"))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }

        }

        private void UserMainScreen_DockChanged(object sender, EventArgs e)
        {
            FillDgvColor();
        }
    }
}
