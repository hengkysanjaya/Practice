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
    public partial class MainForm : Form
    {
        public static User LoggedUser;
        public static SessionLog CurrentSession;
        public event RealTimeCallback adminCallback;

        session1Entities entities = new session1Entities();

        public MainForm(User user)
        {
            InitializeComponent();

            LoggedUser = user;
            CurrentSession = new SessionLog()
            {
                UserID = user.ID,
                LoginTime = DateTime.Now
            };
        }

        private void CheckLastSession()
        {
            var lastSession = entities.SessionLogs
                .Where(x => x.UserID == LoggedUser.ID)
                .OrderByDescending(x => x.LoginTime)
                .FirstOrDefault();

            if(lastSession != null)
            {
                if(!lastSession.LogoutTime.HasValue)
                {
                    MonitoringForm form = new MonitoringForm(lastSession);
                    while(form.ShowDialog() != DialogResult.OK) { }
                }
            }
        }

        private void InsertSession()
        {
            entities.SessionLogs.Add(CurrentSession);
            entities.SaveChanges();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckLastSession();
            InsertSession();

            Role role = entities.Roles
                .Where(x => x.ID == LoggedUser.RoleID)
                .FirstOrDefault();

            if (role.Title.Equals("User"))
            {
                addUserToolStripMenuItem.Visible = false;

                UserMainScreen screen = new UserMainScreen();
                panel1.Controls.Add(screen);
                screen.Dock = DockStyle.Fill;
            }
            else
            {
                AdministratorMainScreen screen = new AdministratorMainScreen();
                panel1.Controls.Add(screen);
                screen.Dock = DockStyle.Fill;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionLog sessLog = entities.SessionLogs
                .Where(x => x.SessionLogID == CurrentSession.SessionLogID)
                .FirstOrDefault();

            sessLog.LogoutTime = DateTime.Now;
            entities.SaveChanges();

            Application.Exit();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();

            if(form.ShowDialog() == DialogResult.OK)
            {
                adminCallback();
            }
        }
    }

    public delegate void RealTimeCallback();
}
