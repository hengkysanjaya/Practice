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

namespace DataValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook wb = ExcelApp.Workbooks.Add();
            Excel.Worksheet ws = wb.ActiveSheet;

            ws.Range["A1"].Validation.Add(Excel.XlDVType.xlValidateList, Type.Missing, Excel.XlFormatConditionOperator.xlBetween, "AA,BB,CC,DD,EE,FF,GG,HH");
            //ws.Range["A2"].Validation.Add(Excel.XlDVType.xlValidateList, Type.Missing, Excel.XlFormatConditionOperator.xlBetween, "");
            using (SaveFileDialog sf = new SaveFileDialog())
            {
                sf.Filter = "Excel Files|*.xlsx";
                if(sf.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sf.FileName);
                    wb.Close();
                    ExcelApp.Quit();
                }
            }
        }
    }
}
