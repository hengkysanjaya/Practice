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

namespace FileTextToList
{
    public partial class core : Form
    {
        public static DateTime coreLogin;
        public static string myPath = Application.StartupPath + "\\file.txt";
        public static string coreEmail;

        public core()
        {
            InitializeComponent();
        }

        private void core_Load(object sender, EventArgs e)
        {

        }


        public List<Data> GetList()
        {
            List<Data> listData = new List<Data>();

            string[] data = File.ReadAllLines(myPath);

            for (int i = 0; i < data.Length; i++)
            {
                if (!string.IsNullOrEmpty(data[i]))
                {
                    string[] split = data[i].Split(';');
                    listData.Add(new Data()
                    {
                        Email = split[0].Trim(),
                        LogIn = split[1].Trim(),
                        LogOff = split[2].Trim(),
                        Status = split[3].Trim()
                    });
                }
            }
            return listData;
        }

        public void WriteData(bool normalClose, bool addNew, List<Data> listData = null)
        {
            try
            {

                string data = "";
                if (addNew)
                {
                    data = File.ReadAllText(myPath);
                    if (normalClose)
                    {
                        data += $"hengkysanjaya204@yahoo.co.id;{coreLogin};{DateTime.Now};normal";
                    }
                    else
                    {
                        data += $"hengkysanjaya204@yahoo.co.id;{coreLogin};;";
                    }
                }
                else
                {
                    data = "";
                    foreach (var a in listData)
                    {
                        data += $"{a.Email};{a.LogIn};{a.LogOff};{a.Status}" + Environment.NewLine;
                    }
                }

                File.WriteAllText(myPath, data + Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    public class Data
    {
        public string Email { get; set; }
        public string LogIn { get; set; }
        public string LogOff { get; set; }
        public string Status { get; set; }
    }
}
