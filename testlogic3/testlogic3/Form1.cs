using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testlogic3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Foods> listFoods = new List<Foods>()
        {
            new Foods() {Foodname = "A",FoodStock = 10 },
            new Foods() {Foodname = "A",FoodStock = 20 },
            new Foods() {Foodname = "B",FoodStock = 5 },
            new Foods() {Foodname = "B",FoodStock = 10 },
        };
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int neededStock = 15;
            string foodname = "A";

            List<Foods> myData = new List<Foods>();
            do
            {
                var q = listFoods.Where(x => x.Foodname == foodname && x.FoodStock > 0).FirstOrDefault();
                
                if (neededStock < q.FoodStock)
                {
                    myData.Add(new Foods()
                    {
                        Foodname = q.Foodname,
                        FoodStock = neededStock
                    });
                    q.FoodStock -= neededStock;
                    neededStock = 0;
                    
                }
                else
                {
                    myData.Add(new Foods()
                    {
                        Foodname= q.Foodname,
                        FoodStock = q.FoodStock
                    });
                    neededStock -= q.FoodStock;
                    q.FoodStock = 0;
                }

            } while (neededStock > 0);
            dataGridView1.DataSource = myData.ToList();
            dataGridView2.DataSource = listFoods.ToList();
        }
    }
    class Foods
    {
        public string Foodname { get; set; }
        public int FoodStock { get; set; }
    }
}
