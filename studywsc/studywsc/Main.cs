using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studywsc
{
    public partial class Main : core
    {
        public Main()
        {
            InitializeComponent();
        }
        List<History> listHistory;
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            listHistory.Add(new History()
            {
                ID = listHistory.Count + 1,
                Email = coreEmail,
                Login = coreLoginTime,
                Logout = DateTime.Now.ToString(),
                Reason = normalClose ? "normal" : ""
            });
            WriteHistory(listHistory);
            coreLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            listHistory = GetList();
            dataGridView1.DataSource = listHistory.ToList();
        }

        bool normalClose = false;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalClose = true;
            this.Close();
        }
    }
}
