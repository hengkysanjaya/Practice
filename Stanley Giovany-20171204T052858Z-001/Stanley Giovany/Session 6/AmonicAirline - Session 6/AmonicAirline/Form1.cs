using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmonicAirline
{
    public partial class Form1 : Form
    {
        DateTime formOpened;
        session6Entities entities = new session6Entities();
        List<Schedule> schedules;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formOpened = DateTime.Now;
            schedules = entities.Schedules.ToList();
            LoadFlightsSummary();
            LoadNumberOfPassengerFlying();
            LoadTopCustomers();
            LoadTopOffice();
            LoadRevenueFromTicketSales();
            LoadPercentageOfEmptySeats();
            CalculateGenerationTime();
        }

        private void CalculateGenerationTime()
        {
            DateTime finished = DateTime.Now;
            TimeSpan duration = finished - formOpened;

            lblGenerateIn.Text = $"Report generated in {duration.TotalSeconds} seconds";
        }

        private void LoadPercentageOfEmptySeats()
        {
            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);

            // Calculate this week
            DateTime thisWeek = currentDate.AddDays(-7);
            var thisWeekSchedules = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= thisWeek &&
                    x.Date + x.Time <= currentDate)
                .ToList();

            var thisWeekEmptySeat = thisWeekSchedules
                .Sum(x => x.Aircraft.TotalSeats - (x.Tickets.Count() > 0 ? x.Tickets.Where(y => y.Confirmed).Count() : 0));

            var thisWeekTotalSeat = thisWeekSchedules
                .Sum(x => x.Aircraft.TotalSeats);

            var thisWeekPercentage = thisWeekTotalSeat == 0 ? 0 : thisWeekEmptySeat * 100 / thisWeekTotalSeat;
            lblThisWeek.Text = $"{thisWeekPercentage} %";

            // Calculate last week
            DateTime lastWeek = currentDate.AddDays(-14);
            var lastWeekSchedules = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastWeek &&
                    x.Date + x.Time <= thisWeek)
                .ToList();

            var lastWeekEmptySeat = lastWeekSchedules
                .Sum(x => x.Aircraft.TotalSeats - (x.Tickets.Count() > 0 ? x.Tickets.Where(y => y.Confirmed).Count() : 0));

            var lastWeekTotalSeat = lastWeekSchedules
                .Sum(x => x.Aircraft.TotalSeats);

            var lastWeekPercentage = lastWeekTotalSeat == 0 ? 0 : lastWeekEmptySeat * 100 / lastWeekTotalSeat;
            lblLastWeek.Text = $"{lastWeekPercentage} %";

            // Calculate two weeks ago
            DateTime twoWeeksAgo = currentDate.AddDays(-21);
            var twoWeeksSchedules = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= twoWeeksAgo &&
                    x.Date + x.Time <= lastWeek)
                .ToList();

            var twoWeeksEmptySeat = twoWeeksSchedules
                .Sum(x => x.Aircraft.TotalSeats - (x.Tickets.Count() > 0 ? x.Tickets.Where(y => y.Confirmed).Count() : 0));

            var twoWeeksTotalSeat = twoWeeksSchedules
                .Sum(x => x.Aircraft.TotalSeats);

            var twoWeeksPercentage = twoWeeksTotalSeat == 0 ? 0 : twoWeeksEmptySeat * 100 / twoWeeksTotalSeat;
            lblTwoWeeksAgo.Text = $"{twoWeeksPercentage} %";
        }

        private void LoadRevenueFromTicketSales()
        {
            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);

            // Calculate yesterday
            DateTime yesterday = currentDate.AddDays(-1);
            var yesterdaySoldTickets = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= yesterday &&
                    x.Date + x.Time <= currentDate)
                .SelectMany(x => x.Tickets)
                .Where(x => x.Confirmed)
                .ToList();

            var yesterdayRevenues = yesterdaySoldTickets
                .Sum(x => x.CabinTypeID == 1 ? x.Schedule.EconomyPrice :
                          x.CabinTypeID == 2 ? x.Schedule.EconomyPrice * 135 / 100 :
                          x.CabinTypeID == 3 ? (x.Schedule.EconomyPrice * 135 / 100) * 130 / 100 : 0);

            lblYesterday.Text = $"${yesterdayRevenues:0}";

            // Calculate two days ago
            DateTime twoDaysAgo = currentDate.AddDays(-2);
            var twoDaysAgoSoldTickets = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= twoDaysAgo &&
                    x.Date + x.Time <= yesterday)
                .SelectMany(x => x.Tickets)
                .Where(x => x.Confirmed)
                .ToList();

            var twoDaysAgoRevenues = twoDaysAgoSoldTickets
                .Sum(x => x.CabinTypeID == 1 ? x.Schedule.EconomyPrice :
                          x.CabinTypeID == 2 ? x.Schedule.EconomyPrice * 135 / 100 :
                          x.CabinTypeID == 3 ? (x.Schedule.EconomyPrice * 135 / 100) * 130 / 100 : 0);

            lblTwoDaysAgo.Text = $"${twoDaysAgoRevenues:0}";

            // Calculate three days ago
            DateTime threeDaysAgo = currentDate.AddDays(-3);
            var threeDaysAgoSoldTickets = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= threeDaysAgo &&
                    x.Date + x.Time <= twoDaysAgo)
                .SelectMany(x => x.Tickets)
                .Where(x => x.Confirmed)
                .ToList();

            var threeDaysAgoRevenues = threeDaysAgoSoldTickets
                .Sum(x => x.CabinTypeID == 1 ? x.Schedule.EconomyPrice :
                          x.CabinTypeID == 2 ? x.Schedule.EconomyPrice * 135 / 100 :
                          x.CabinTypeID == 3 ? (x.Schedule.EconomyPrice * 135 / 100) * 130 / 100 : 0);

            lblThreeDaysAgo.Text = $"${threeDaysAgoRevenues:0}";
        }

        private void LoadTopOffice()
        {
            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);
            DateTime lastMonth = currentDate.AddDays(-30);

            var offices = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= currentDate)
                .SelectMany(x => x.Tickets)
                .Where(x => x.Confirmed)
                .Select(x => x.User)
                .GroupBy(x => x.Office)
                .Select(x => new
                {
                    Office = x.Key,
                    TotalSold = x.ToList().Count()
                })
                .OrderByDescending(x => x.TotalSold)
                .ToList();

            lblTopOffice1.Text = "1. " + (offices.Count > 0 ? $"{offices[0].Office.Title}" : "None");
            lblTopOffice2.Text = "2. " + (offices.Count > 1 ? $"{offices[1].Office.Title}" : "None");
            lblTopOffice3.Text = "3. " + (offices.Count > 2 ? $"{offices[2].Office.Title}" : "None");
        }

        private void LoadTopCustomers()
        {
            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);
            DateTime lastMonth = currentDate.AddDays(-30);

            var customers = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= currentDate)
                .SelectMany(x => x.Tickets)
                .Where(x => x.Confirmed)
                .GroupBy(x => $"{x.Firstname} {x.Lastname}")
                .Select(x => new
                {
                    User = x.Key,
                    TotalTicket = x.ToList().Count
                })
                .OrderByDescending(x => x.TotalTicket)
                .ToList();

            lblTopCustomer1.Text = "1. " + (customers.Count > 0 ? $"{customers[0].User} ({customers[0].TotalTicket} Tickets)" : "None");
            lblTopCustomer2.Text = "2. " + (customers.Count > 1 ? $"{customers[1].User} ({customers[1].TotalTicket} Tickets)" : "None");
            lblTopCustomer3.Text = "3. " + (customers.Count > 2 ? $"{customers[2].User} ({customers[2].TotalTicket} Tickets)" : "None");
        }

        private void LoadNumberOfPassengerFlying()
        {
            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);
            DateTime lastMonth = currentDate.AddDays(-30);

            var passengerFlying = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= currentDate)
                .GroupBy(x => x.Date)
                .Select(x => new
                {
                    Date = x.Key,
                    TotalFlying = x.ToList().Sum(y => y.Tickets.Count() > 0 ? y.Tickets.Where(z => z.Confirmed).Count() : 0)
                })
                .Where(x => x.TotalFlying > 0)
                .OrderBy(x => x.TotalFlying)
                .ToList();

            lblBusiestDay.Text = passengerFlying.Count > 0 ? 
                $"{passengerFlying[passengerFlying.Count - 1].Date.ToString("dd/MM")} with {passengerFlying[passengerFlying.Count - 1].TotalFlying} flying" : "None";
            lblQuietDay.Text = passengerFlying.Count > 1 ? 
                $"{passengerFlying[0].Date.ToString("dd/MM")} with {passengerFlying[0].TotalFlying} flying" : "None";
        }

        private void LoadFlightsSummary()
        {
            DateTime lastMonth = formOpened.AddDays(-30);

            var confirmed = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= formOpened)
                .Count();

            var cancelled = schedules
                .Where(x =>
                    !x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= formOpened)
                .Count();

            DateTime currentDate = new DateTime(formOpened.Year, formOpened.Month, formOpened.Day);
            lastMonth = currentDate.AddDays(-30);

            var averageDailyFlightTime = schedules
                .Where(x =>
                    x.Confirmed &&
                    x.Date + x.Time >= lastMonth &&
                    x.Date + x.Time <= currentDate)
                .Count() > 0 ? 
                schedules
                    .Where(x =>
                        x.Confirmed &&
                        x.Date + x.Time >= lastMonth &&
                        x.Date + x.Time <= currentDate)
                    .GroupBy(x => x.Date)
                    .Select(x => new
                    {
                        Total = x.ToList().Sum(y => y.Route.FlightTime)
                    })
                    .Average(x => x.Total) : 0;

            lblNumberConfirmed.Text = confirmed.ToString();
            lblNumberCancelled.Text = cancelled.ToString();
            lblAverageDailyFlightTime.Text = $"{averageDailyFlightTime:0} minutes";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
