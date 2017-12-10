using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ac = new AgeCriteria(1, 200).Min.ToString();
                MessageBox.Show(ac);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    public class AgeCriteria
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string display { get; set; }
        public AgeCriteria(int min, int max)
        {
            if (min == 0)
            {
                throw new Exception("Minimal must be greater than 0");
            }
            else if (max > 100)
            {
                throw new Exception("Maximal must be smaller than 100");
            }
        }
        
    }
}
