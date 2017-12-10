using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchRouteReview2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<FlightSchedule> flights = new List<FlightSchedule>(new FlightSchedule[] {
            new FlightSchedule() { From=6, To=1, Time=DateTime.Parse("00:22") },
            new FlightSchedule() { From=8, To=6, Time=DateTime.Parse("00:26") },
            new FlightSchedule() { From=10, To=1, Time=DateTime.Parse("00:30") },
            new FlightSchedule() { From=8, To=7, Time=DateTime.Parse("00:58") },
            new FlightSchedule() { From=10, To=9, Time=DateTime.Parse("01:03") },
            new FlightSchedule() { From=4, To=6, Time=DateTime.Parse("01:30") },
            new FlightSchedule() { From=6, To=1, Time=DateTime.Parse("02:05") },
            new FlightSchedule() { From=10, To=9, Time=DateTime.Parse("02:22") },
            new FlightSchedule() { From=2, To=9, Time=DateTime.Parse("03:02") },
            new FlightSchedule() { From=6, To=3, Time=DateTime.Parse("03:05") },
            new FlightSchedule() { From=1, To=9, Time=DateTime.Parse("03:50") },
            new FlightSchedule() { From=3, To=7, Time=DateTime.Parse("03:50") },
            new FlightSchedule() { From=4, To=7, Time=DateTime.Parse("04:33") },
            new FlightSchedule() { From=7, To=1, Time=DateTime.Parse("04:39") },
            new FlightSchedule() { From=1, To=2, Time=DateTime.Parse("04:40") },
            new FlightSchedule() { From=1, To=9, Time=DateTime.Parse("04:48") },
            new FlightSchedule() { From=6, To=2, Time=DateTime.Parse("04:50") },
            new FlightSchedule() { From=2, To=10, Time=DateTime.Parse("05:24") },
            new FlightSchedule() { From=1, To=9, Time=DateTime.Parse("06:44") },
            new FlightSchedule() { From=4, To=10, Time=DateTime.Parse("06:46") },
            new FlightSchedule() { From=8, To=5, Time=DateTime.Parse("06:49") },
            new FlightSchedule() { From=4, To=5, Time=DateTime.Parse("06:53") },
            new FlightSchedule() { From=4, To=6, Time=DateTime.Parse("08:24") },
            new FlightSchedule() { From=4, To=3, Time=DateTime.Parse("08:25") },
            new FlightSchedule() { From=5, To=9, Time=DateTime.Parse("08:33") },
            new FlightSchedule() { From=5, To=7, Time=DateTime.Parse("08:44") },
            new FlightSchedule() { From=7, To=9, Time=DateTime.Parse("09:33") },
            new FlightSchedule() { From=3, To=6, Time=DateTime.Parse("10:14") },
            new FlightSchedule() { From=8, To=10, Time=DateTime.Parse("10:32") },
            new FlightSchedule() { From=4, To=10, Time=DateTime.Parse("10:52") },
            new FlightSchedule() { From=4, To=6, Time=DateTime.Parse("10:56") },
            new FlightSchedule() { From=4, To=7, Time=DateTime.Parse("11:29") },
            new FlightSchedule() { From=6, To=9, Time=DateTime.Parse("11:40") },
            new FlightSchedule() { From=10, To=2, Time=DateTime.Parse("11:46") },
            new FlightSchedule() { From=4, To=7, Time=DateTime.Parse("11:51") },
            new FlightSchedule() { From=1, To=10, Time=DateTime.Parse("12:06") },
            new FlightSchedule() { From=5, To=8, Time=DateTime.Parse("12:06") },
            new FlightSchedule() { From=1, To=4, Time=DateTime.Parse("12:16") },
            new FlightSchedule() { From=5, To=2, Time=DateTime.Parse("12:20") },
            new FlightSchedule() { From=3, To=1, Time=DateTime.Parse("12:28") },
            new FlightSchedule() { From=2, To=9, Time=DateTime.Parse("12:35") },
            new FlightSchedule() { From=3, To=7, Time=DateTime.Parse("12:43") },
            new FlightSchedule() { From=10, To=4, Time=DateTime.Parse("13:07") },
            new FlightSchedule() { From=7, To=3, Time=DateTime.Parse("13:17") },
            new FlightSchedule() { From=8, To=1, Time=DateTime.Parse("13:35") },
            new FlightSchedule() { From=8, To=1, Time=DateTime.Parse("14:00") },
            new FlightSchedule() { From=8, To=7, Time=DateTime.Parse("14:01") },
            new FlightSchedule() { From=1, To=6, Time=DateTime.Parse("14:12") },
            new FlightSchedule() { From=2, To=4, Time=DateTime.Parse("14:12") },
            new FlightSchedule() { From=2, To=3, Time=DateTime.Parse("14:17") },
            new FlightSchedule() { From=7, To=8, Time=DateTime.Parse("14:28") },
            new FlightSchedule() { From=8, To=1, Time=DateTime.Parse("14:28") },
            new FlightSchedule() { From=5, To=10, Time=DateTime.Parse("14:49") },
            new FlightSchedule() { From=3, To=8, Time=DateTime.Parse("15:06") },
            new FlightSchedule() { From=7, To=3, Time=DateTime.Parse("15:26") },
            new FlightSchedule() { From=5, To=3, Time=DateTime.Parse("15:32") },
            new FlightSchedule() { From=1, To=10, Time=DateTime.Parse("15:46") },
            new FlightSchedule() { From=10, To=9, Time=DateTime.Parse("15:46") },
            new FlightSchedule() { From=3, To=7, Time=DateTime.Parse("15:53") },
            new FlightSchedule() { From=10, To=3, Time=DateTime.Parse("16:05") },
            new FlightSchedule() { From=8, To=3, Time=DateTime.Parse("16:24") },
            new FlightSchedule() { From=6, To=2, Time=DateTime.Parse("16:47") },
            new FlightSchedule() { From=6, To=7, Time=DateTime.Parse("16:56") },
            new FlightSchedule() { From=1, To=10, Time=DateTime.Parse("16:57") },
            new FlightSchedule() { From=4, To=3, Time=DateTime.Parse("16:59") },
            new FlightSchedule() { From=1, To=10, Time=DateTime.Parse("17:28") },
            new FlightSchedule() { From=5, To=4, Time=DateTime.Parse("17:32") },
            new FlightSchedule() { From=9, To=6, Time=DateTime.Parse("17:52") },
            new FlightSchedule() { From=6, To=8, Time=DateTime.Parse("18:07") },
            new FlightSchedule() { From=7, To=6, Time=DateTime.Parse("18:08") },
            new FlightSchedule() { From=2, To=7, Time=DateTime.Parse("18:40") },
            new FlightSchedule() { From=10, To=8, Time=DateTime.Parse("20:08") },
            new FlightSchedule() { From=4, To=2, Time=DateTime.Parse("20:47") },
            new FlightSchedule() { From=3, To=8, Time=DateTime.Parse("20:49") },
            new FlightSchedule() { From=4, To=2, Time=DateTime.Parse("20:55") },
            new FlightSchedule() { From=4, To=8, Time=DateTime.Parse("21:15") },
            new FlightSchedule() { From=3, To=10, Time=DateTime.Parse("21:20") },
            new FlightSchedule() { From=6, To=7, Time=DateTime.Parse("21:20") },
            new FlightSchedule() { From=5, To=8, Time=DateTime.Parse("21:42") },
            new FlightSchedule() { From=7, To=8, Time=DateTime.Parse("21:42") },
            new FlightSchedule() { From=8, To=1, Time=DateTime.Parse("22:17") },
            new FlightSchedule() { From=6, To=8, Time=DateTime.Parse("22:36") },
            new FlightSchedule() { From=5, To=10, Time=DateTime.Parse("23:13") },
            new FlightSchedule() { From=4, To=3, Time=DateTime.Parse("23:15") },
            new FlightSchedule() { From=6, To=1, Time=DateTime.Parse("23:17") },
            new FlightSchedule() { From=9, To=4, Time=DateTime.Parse("23:25") },
            new FlightSchedule() { From=5, To=3, Time=DateTime.Parse("23:44") },
            new FlightSchedule() { From=6, To=7, Time=DateTime.Parse("23:45") },
            new FlightSchedule() { From=6, To=4, Time=DateTime.Parse("23:48") },
            new FlightSchedule() { From=7, To=5, Time=DateTime.Parse("23:54") },
            new FlightSchedule() { From=10, To=9, Time=DateTime.Parse("23:56") },
            new FlightSchedule() { From=9, To=2, Time=DateTime.Parse("23:58") },
            new FlightSchedule() { From=9, To=5, Time=DateTime.Parse("07:58") },
            new FlightSchedule() { From=5, To=2, Time=DateTime.Parse("11:00") },
        });

        private void button1_Click(object sender, EventArgs e)
        {
            int from = (int)comboBox1.SelectedItem;
            int to = (int)comboBox2.SelectedItem;
            int Total = Search(from, to, DateTime.Parse("00:01"), 0, new List<FlightSchedule>());
            dataGridView1.DataSource = listHeader.ToList();
        }

        List<Header> listHeader = new List<Header>();
        private int Search(int From, int To, DateTime StartTime,int Transit,List<FlightSchedule> visited)
        {
            if (Transit > 4) return 0;

            if (visited.Where(x => x.From == From).Count() > 0)
            {
                return 0;
            }

            if (From == To)
            {
                listHeader.Add(new Header()
                {
                    listSchedule = visited
                });
                return 1;
            }
            var q = flights.Where(x => x.From == From);
            int bisa = 0;
            foreach(var a in q)
            {
                List<FlightSchedule> list = new List<FlightSchedule>(visited);
                list.Add(a);
                bisa += Search(a.To, To, a.Time, Transit + 1, list);
            }

            return bisa;
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

            for (int i = 0; i < 20; i++)
            {
                Button btn = new Button();
                btn.Text = "test";
                btn.Size = new Size(50, 50);
                flowLayoutPanel1.Controls.Add(btn);
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(colorDialog1.Color.Name);
            }
        }
    }
    class Header
    {
        public string Route
        {
            get
            {
                return String.Join(", ",listSchedule.Select(x=>x.From).ToArray()) +" , "+ listSchedule.Last().To;
            }
        }

        public List<FlightSchedule> listSchedule { get; set; }
        public Header()
        {
            listSchedule = new List<FlightSchedule>();
        }
    }

    class FlightSchedule
    {
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Time { get; set; }
    }
}
