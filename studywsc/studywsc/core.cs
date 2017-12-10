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

namespace studywsc
{
    public partial class core : Form
    {
        public static Login coreLogin;
        public static string myPath = Application.StartupPath + "\\file.txt";
        public static string coreLoginTime;
        public static string coreEmail;

        public core()
        {
            InitializeComponent();
        }

        private void core_Load(object sender, EventArgs e)
        {
            if(coreLogin == null)
            {
                coreLogin = new Login();
            }
        }

        public List<History> GetList()
        {
            List<History> listHistory = new List<History>();
            string[] lines = File.ReadAllLines(myPath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(';');
                listHistory.Add(new History()
                {
                    ID = i+1,
                    Email = split[1].Trim(),
                    Login = split[2].Trim(),
                    Logout = split[3].Trim(),
                    Reason = split[4].Trim()
                });
            }
            return listHistory;
        }
        public void WriteHistory(List<History> listHistory)
        {
            string data = "";
            foreach(var a in listHistory)
            {
                data += $"{a.ID};{a.Email};{a.Login};{a.Logout};{a.Reason}" + Environment.NewLine;
            }
            File.WriteAllText(myPath, data);
        }
    }
    public class History
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Logout { get; set; }
        public string Reason { get; set; }
    }
}
