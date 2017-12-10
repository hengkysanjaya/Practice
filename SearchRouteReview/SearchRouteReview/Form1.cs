using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchRouteReview
{
    public partial class Form1 : Form
    {
        List<Schedule> listSchedule = new List<Schedule>()
        {
            new Schedule() { From = 2, To = 10, DateTime = DateTime.Parse("3:00") },
            new Schedule() { From = 10, To = 9, DateTime = DateTime.Parse("6:13") },
            new Schedule() { From = 9, To = 5, DateTime = DateTime.Parse("6:0") },
            new Schedule() { From = 10, To = 9, DateTime = DateTime.Parse("6:10") },
            new Schedule() { From = 2, To = 5, DateTime = DateTime.Parse("14:53") },
            new Schedule() { From = 6, To = 9, DateTime = DateTime.Parse("13:41") },
            new Schedule() { From = 4, To = 2, DateTime = DateTime.Parse("18:27") },
            new Schedule() { From = 1, To = 7, DateTime = DateTime.Parse("0:24") },
            new Schedule() { From = 8, To = 8, DateTime = DateTime.Parse("2:14") },
            new Schedule() { From = 9, To = 10, DateTime = DateTime.Parse("18:36") },
            new Schedule() { From = 5, To = 3, DateTime = DateTime.Parse("20:46") },
            new Schedule() { From = 4, To = 1, DateTime = DateTime.Parse("12:49") },
            new Schedule() { From = 4, To = 9, DateTime = DateTime.Parse("22:17") },
            new Schedule() { From = 9, To = 10, DateTime = DateTime.Parse("12:18") },
            new Schedule() { From = 7, To = 9, DateTime = DateTime.Parse("22:56") },
            new Schedule() { From = 7, To = 4, DateTime = DateTime.Parse("3:35") },
            new Schedule() { From = 8, To = 1, DateTime = DateTime.Parse("2:39") },
            new Schedule() { From = 10, To = 6, DateTime = DateTime.Parse("1:3") },
            new Schedule() { From = 8, To = 6, DateTime = DateTime.Parse("11:40") },
            new Schedule() { From = 5, To = 3, DateTime = DateTime.Parse("13:49") },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a= Search((int)comboBox1.SelectedItem, (int)comboBox2.SelectedItem, DateTime.Parse("00:01"), 0, new List<Schedule>());
            MessageBox.Show(a.ToString());
            dataGridView1.DataSource = listHeader.ToList();
        }

        List<Header> listHeader = new List<Header>();
        private int Search(int From, int To, DateTime dt, int transit,List<Schedule> visited)
        {
            if (transit > 4) return 0;

            if(From == To)
            {
                listHeader.Add(new Header()
                {
                    listJadwal = visited
                });

                return 1;
            }

            var q = listSchedule.Where(x => x.From == From && x.DateTime.TimeOfDay >= dt.TimeOfDay);
            
            int bisa = 0;
            foreach(var a in q)
            {
                List<Schedule> list = new List<Schedule>(visited);
                list.Add(a);
                bisa += Search(a.To, To, a.DateTime, transit + 1, list);
            }

            return bisa;
        }
    }

    class Header
    {
        public string Route {
            get
            {
                return string.Join(", ", listJadwal.Select(x => x.From).ToArray()) + ", " + listJadwal.Last().To;
            }
        }
        public List<Schedule> listJadwal { get; set; }
        public Header()
        {
            listJadwal = new List<Schedule>();
        }
    }

    class Schedule
    {
        public int To { get; set; }
        public int From { get; set; }
        public DateTime DateTime { get; set; }
    }
}
