using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportExcelImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string defaultPath = Application.StartupPath;
        private void Form1_Load(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;


            Excel.Range xlRange = xlWorksheet.Range[xlWorksheet.Cells[1, 4], xlWorksheet.Cells[3, 8]];
            xlRange.Font.Size = 25;
            xlRange.Font.Name = "Arial";
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Font.Bold = true;
            xlRange.Merge();
            xlRange.Value = "This is the Title";


            xlWorksheet.Shapes.AddPicture(defaultPath + "\\logo-2015-full-colour.png", Microsoft.Office.Core.MsoTriState.msoCTrue, Microsoft.Office.Core.MsoTriState.msoFalse, 0, 0, 150, 100);

            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Files|*.xlsx";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(sf.FileName);
                }
            }
            xlApp.Quit();
        }
    }
}
