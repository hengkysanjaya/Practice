using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQRankOver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<testing> listtesting = new List<testing>()
            {
                new testing() {Nama = "AAA",Score = 100 ,Gender = "Male"},
                new testing() {Nama = "BBB",Score = 50 ,Gender = "FeMale"},
                new testing() {Nama = "CCC",Score = 65 ,Gender = "Male"},
                new testing() {Nama = "DDD",Score = 70 ,Gender = "FeMale"},
            };

            var q2 = listtesting.Select(x => new
            {
                Name = x.Nama,
                Rank = listtesting.Count(y => y.Score > x.Score && y.Gender == x.Gender) + 1,
            });
            foreach(var a in q2)
            {
                MessageBox.Show(a.ToString());
            }
            //var q = data.Select(x => new
            //{
            //    Rank = data.Count(y => y > x) + 1,
            //    x
            //});

            //foreach(var a in q)
            //{
            //    MessageBox.Show(a.ToString());
            //}
        }

        List<int> data = new List<int>()
        {
            100,
            10,
            200
        };
    }

    class testing
    {
        public string Nama { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; }

    }

}
