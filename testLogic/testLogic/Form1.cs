using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testLogic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Data> listData = new List<Data>();
        private void button1_Click(object sender, EventArgs e)
        {
            listData.AddRange(new List<Data>()
            {
                new Data() {Name = "AA",Price = 90 },
                new Data() {Name = "AA",Price = 85 },
                new Data() {Name = "AA",Price = 100 },
                new Data() {Name = "BB",Price = 95 },
                new Data() {Name = "BB",Price = 85},
                new Data() {Name = "CC",Price = 90 },
                new Data() {Name = "CC",Price = 85},
            });

            List<Data> result = new List<Data>();
            string name = "";
            int sum = 0;
            for (int i = 0; i < listData.Count; i++)
            {
                if (name == "")
                {
                    name = listData[i].Name;
                }
                if (name == listData[i].Name)
                {
                    sum += listData[i].Price;
                    if(i == listData.Count - 1)
                    {
                        Add(result, ref name, ref sum, i);
                    }
                }
                else
                {
                    Add(result, ref name, ref sum, i);
                }
            }
            dataGridView1.DataSource = result.ToList();
        }

        private void Add(List<Data> result, ref string name, ref int sum, int i)
        {
            result.Add(new Data() { Name = name, Price = sum });
            name = listData[i].Name;
            sum = listData[i].Price;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class Data
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
