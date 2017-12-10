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

namespace LogFiles
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string email;
        public Form2(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            string defaultPath = Application.StartupPath;
            string myPath = defaultPath + "\\logfile.txt";
            // ----------------- [ Date Time ] -----------------
            // Email : [ Email ]
            // Login : [ Time ]
            // Logout : [ Time ]
            // .................................................

            string data = "";
            if (File.Exists(myPath))
            {
                data = File.ReadAllText(myPath);
            }

            string newData = Environment.NewLine+$"Logout: { DateTime.Now.ToString("hh:mm:ss")}" + Environment.NewLine;
            data = data + newData;

            File.WriteAllText(myPath, data);
        }
    }
}
