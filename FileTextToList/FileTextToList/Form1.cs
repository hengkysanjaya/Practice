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
    public partial class Form1 : core
    {
        bool normalClose = false;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            var q = GetList();
            dataGridView1.DataSource = q.ToList();
            GiveColor();
        }

        private void GiveColor()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(dataGridView1.Rows[i].Cells["Status"].Value.ToString().Trim() != "normal")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;   
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalClose = true;
            this.DialogResult = DialogResult.OK;
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteData(normalClose, true);   
        }

       
    }
    
}
