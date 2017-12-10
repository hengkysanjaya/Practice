using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace session6_review
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dt = DateTime.Now;
            var lastThirtyDays = dt.AddMonths(-1);

            var q = db.Schedules.Where(x => x.Date.Add(x.Time) >= lastThirtyDays
                                        && x.Date.Add(x.Time) <= dt
            ).ToList();


            // Flights
            var confirmed = q.Where(x => x.Confirmed).Count();
            var cancelled = q.Where(x => !x.Confirmed).Count();
            label4.Text = confirmed.ToString();
            label5.Text = cancelled.ToString();

            var averageDailyFlightTime = q.GroupBy(x => x.Date).Average(x => x.Sum(y => y.Route.FlightTime));
            label6.Text = averageDailyFlightTime.ToString() + " minutes";
        
            
            var q2 = db.Tickets.Where(x => q.Select(y => y.ID).Contains(x.ScheduleID)
                                    && x.Confirmed).ToList();

            // Top Customer
            var topCustomer = q2.GroupBy(x => x.Firstname + x.Lastname);
        }

    }
}
