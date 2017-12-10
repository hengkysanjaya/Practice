using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiDimensionArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            int[,] a = {
                {1,2,3 },
                {4,5,6 }
            };

            for(int i = 0; i < a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    MessageBox.Show(a[i, j].ToString());
                }
            }
            // new int[2,3];
            // 000
            // 000

            int[,,] aa = {

            };
        }
    }
}
