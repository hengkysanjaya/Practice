using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartSeleknas_Review
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext DB = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }
        string[] AgregateData = { "Sum", "Max", "Min", "Average", "Count" };
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = AgregateData;
            var q = DB.Employees.Where(x => x.Status != "Sales").Select(y=> new
            {
                display = y.Name,
                value =y.ID
            });
            comboBox1.DataSource = q;
            comboBox1.DisplayMember = "display";
            comboBox1.ValueMember = "value";


            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.Legends.Clear();

            chart1.ChartAreas.Add("myChartArea");
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart1.ChartAreas[0].AxisX.Interval = 1;

            Series s = chart1.Series.Add("");
            

            var q = DB.Employees.Where(x => x.ID.Equals(comboBox1.SelectedValue.ToString())).FirstOrDefault();
            string status = q.Status;
            string agregate = comboBox2.Text;

            if (status == "Owner")
            {
                var qManager = DB.Employees.Where(x => x.ID_Leader.Equals(q.ID));
                //List<int> listPerManager = new List<int>();
                foreach (var a in qManager)
                {
                    int perManager = 0;

                    var qSales = DB.Employees.Where(x => x.ID_Leader.Equals(a.ID));
                    List<int> listPerSales = new List<int>();
                    foreach (var b in qSales)
                    {
                        var query = DB.HeaderTransactions.Where(x => x.ID_Employee.Equals(b.ID));

                        int result = 0;
                        if (agregate == "Sum")
                        {
                            result = query.Sum(y => y.DetailTransactions.Sum(z => (z.Product.Price_Customer - z.Product.Price_Sales) * z.Quantity));
                        }
                        else if (agregate == "Max")
                        {
                            result = query.Max(y => y.DetailTransactions.Sum(z => (z.Product.Price_Customer - z.Product.Price_Sales) * z.Quantity));
                        }
                        else if (agregate == "Min")
                        {
                            result = query.Min(y => y.DetailTransactions.Sum(z => (z.Product.Price_Customer - z.Product.Price_Sales) * z.Quantity));
                        }
                        else if (agregate == "Average")
                        {
                            result = (int)query.Average(y => y.DetailTransactions.Sum(z => (z.Product.Price_Customer - z.Product.Price_Sales) * z.Quantity));
                        }
                        else if (agregate == "Count")
                        {
                            result = query.Sum(y => y.DetailTransactions.Count());
                        }
                        listPerSales.Add(result);
                    }

                    if (agregate == "Sum")
                    {
                        perManager = listPerSales.Sum();
                    }
                    else if (agregate == "Max")
                    {
                        perManager = listPerSales.Max();
                    }
                    else if (agregate == "Min")
                    {
                        perManager = listPerSales.Min();
                    }
                    else if (agregate == "Average")
                    {
                        perManager = (int)listPerSales.Average();
                    }
                    else if (agregate == "Count")
                    {
                        perManager = listPerSales.Sum();
                    }
                    s.ChartArea = "myChartArea";
                    s.IsValueShownAsLabel = true;
                    s.Points.AddXY(a.ID, perManager);
                }
            }
            else if (status == "Manager")
            {
                var qSales = DB.Employees.Where(x => x.ID_Leader.Equals(comboBox1.SelectedValue.ToString()));
                foreach(var a in qSales)
                {
                    int PerSales = 0;

                    var query = DB.HeaderTransactions.Where(x => x.ID_Employee.Equals(a.ID));

                    if (agregate == "Sum")
                    {
                        PerSales = query.Sum(x => x.DetailTransactions.Sum(y => (y.Product.Price_Customer - y.Product.Price_Sales) * y.Quantity));
                    }
                    else if (agregate == "Average")
                    {
                        PerSales = (int)query.Average(x => x.DetailTransactions.Sum(y => (y.Product.Price_Customer - y.Product.Price_Sales) * y.Quantity));
                    }
                    s.ChartArea = "myChartArea";
                    s.IsValueShownAsLabel = true;
                    s.Points.AddXY(a.ID, PerSales);
                }
            }
        }
    }
}
