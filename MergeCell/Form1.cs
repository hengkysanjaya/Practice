using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MergeCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

            Excel.Range xlRange1 = xlWorksheet.Range["A1:D2"];
            xlRange1.Merge();
            xlRange1.Value = "This is title";
            xlRange1.Font.Name = "Open Sans";
            xlRange1.Font.Size = 20;
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Files |*.xlsx";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(sf.FileName);
                }
            }
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);

        }
    }
}
