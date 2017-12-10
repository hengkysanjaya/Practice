using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTextToList
{
    public partial class Form2 : core
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<Data> listData;
        public Form2(List<Data> listData)
        {
            InitializeComponent();
            this.listData = listData;
        }

        Data current;
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                current = listData.Where(x => x.Email == coreEmail).FirstOrDefault();
                label1.Text = $"{current.Email} Login Time {current.LogIn} Logout Time {current.LogOff}";
            }
            catch
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            current.Status = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            WriteData(true, false, listData);
            Form1 frm = new Form1();
            Login l = new Login();
            this.Close();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                l.Show();
            }
        }
    }
}
