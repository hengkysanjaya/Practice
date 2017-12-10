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
using System.IO;
using System.Diagnostics;

namespace chartReview
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

            Excel.Range titleRange = xlWorksheet.Range[xlWorksheet.Cells[1, 4], xlWorksheet.Cells[4, 8]];
            titleRange.Merge();
            titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            titleRange.Value = "This is the Title";
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 20;
            titleRange.Font.Name = "Arial";
            

            string logoPath = Application.StartupPath + @"\logo-2015-full-colour.png";
            xlWorksheet.Shapes.AddPicture(logoPath, Microsoft.Office.Core.MsoTriState.msoCTrue, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 150, 60);

            xlWorksheet.Cells[6, 2].Value = "2011";

            xlWorksheet.Cells[7, 1].Value = "Under 18";
            xlWorksheet.Cells[8, 1].Value = "18 To 27";
            xlWorksheet.Cells[9, 1].Value = "28 To 44";
            xlWorksheet.Cells[10, 1].Value = "45 To 62";
            xlWorksheet.Cells[11, 1].Value = "Over 62";

            xlWorksheet.Cells[7, 2].Value = "2";
            xlWorksheet.Cells[8, 2].Value = "7";
            xlWorksheet.Cells[9, 2].Value = "7";
            xlWorksheet.Cells[10, 2].Value = "10";
            xlWorksheet.Cells[11, 2].Value = "24";


            Excel.ChartObjects cObjects = xlWorksheet.ChartObjects();
            Excel.ChartObject cObject = cObjects.Add(0, 200, 300, 250);
            Excel.Chart chart = cObject.Chart;
            Excel.Range cRange = xlWorksheet.Range[xlWorksheet.Cells[6, 1], xlWorksheet.Cells[11, 2]];
            chart.HasTitle = true;
            chart.ChartTitle.Text = "This is my chart title";
            chart.SetSourceData(cRange, Excel.XlRowCol.xlRows);

            chart.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue);

            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Files|*.xlsx";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(sf.FileName);
                    xlWorkbook.Close();
                    xlApp.Quit();
                    Process.Start(sf.FileName);
                }
            }
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = 'A' + 1;
            char chr = (char)a;
            MessageBox.Show(chr.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel.Worksheet xlWorksheet = xlWorkbook.ActiveSheet;

            xlWorksheet.Cells[1, 1].Value = "1-A";
            xlWorksheet.Cells[2, 1].Value = "2-B";
            xlWorksheet.Cells[3, 1].Value = "3-C";
            xlWorksheet.Cells[4, 1].Value = "4-D";
            xlWorksheet.Cells[5, 1].Value = "5-E";
            xlWorksheet.Cells[6, 1].Value = "6-F";

            Excel.Range xlRange = xlWorksheet.Range[xlWorksheet.Cells[1, 4], xlWorksheet.Cells[10, 4]];
            xlRange.Validation.Add(Excel.XlDVType.xlValidateList, Type.Missing, Type.Missing, "=$A$1:$A$6");
            xlRange.Borders.Weight = 2;
            xlRange.Borders.Color = Color.Black;

            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Files|*.xlsx";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(sf.FileName);
                    Process.Start(sf.FileName);
                    xlWorkbook.Close();
                    xlApp.Quit();
                }
            }
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
