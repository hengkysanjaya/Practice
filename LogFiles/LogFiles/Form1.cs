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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            LogFiles(textBox1.Text);

            Form2 frm = new Form2(textBox1.Text);
            this.Hide();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        private void LogFiles(string Email)
        {
            string defaultPath = Application.StartupPath;
            string myPath = defaultPath + "\\logfile.txt";
            // ----------------- [ Date Time ] -----------------
            // Email : [ Email ]
            // Login : [ Time ]
            // Logout : [ Time ]
            // .................................................

            string data = "";
            if(File.Exists(myPath))
            {
                data = File.ReadAllText(myPath);
            }

            
            string headerDate = $"-----------------{DateTime.Now.ToString("yyyy-MM-dd ")}-----------------";
            string newData = "";
            if (!data.Contains(headerDate))
            {
                newData = headerDate;
            }

            newData +=   Environment.NewLine + $"Email : {Email}"+
                        Environment.NewLine + $"Login : {DateTime.Now.ToString("hh:mm:ss")}";
            data = data + newData;

            File.WriteAllText(myPath, data);
        }
    }
}
