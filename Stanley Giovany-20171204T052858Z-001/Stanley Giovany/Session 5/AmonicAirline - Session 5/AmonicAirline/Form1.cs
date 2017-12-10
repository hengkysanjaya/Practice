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
        session5Entities entities = new session5Entities();
        Ticket ticket;
        decimal previousPaid;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadAmenities(Ticket ticket)
        {
            flowLayoutPanel1.Controls.Clear();

            var freeAmenities = ticket.CabinType.Amenities;
            var freeAmenitiesId = freeAmenities.Select(x => x.ID).ToList();
            var normalAmenities = entities.Amenities
                .Where(x => !freeAmenitiesId.Contains(x.ID))
                .ToList();

            int sequence = 0;
            foreach (var amenity in freeAmenities)
            {
                CheckBox cb = new CheckBox();
                cb.Text = $"{amenity.Service} (Free)";
                cb.Tag = amenity;
                cb.Enabled = false;
                cb.Checked = true;
                cb.Width = 200;
                flowLayoutPanel1.Controls.Add(cb);

                if (sequence % 2 == 1)
                {
                    flowLayoutPanel1.SetFlowBreak(cb, true);
                }
                sequence++;
            }

            foreach (var amenity in normalAmenities)
            {
                CheckBox cb = new CheckBox();
                cb.Text = $"{amenity.Service} ($" + (amenity.Price == 0 ? "Free" :  amenity.Price.ToString("0")) + ")";
                cb.Tag = amenity;
                cb.Width = 200;
                cb.Click += Cb_Click;
                flowLayoutPanel1.Controls.Add(cb);

                if (sequence % 2 == 1)
                {
                    flowLayoutPanel1.SetFlowBreak(cb, true);
                }
                sequence++;
            }

            var extraAmenities = ticket.AmenitiesTickets
                .Select(x => x.Amenity)
                .ToList();

            foreach (var amenity in extraAmenities)
            {
                var cb = flowLayoutPanel1.Controls
                    .Cast<Control>()
                    .Cast<CheckBox>()
                    .Where(x => ((Amenity)x.Tag).ID == amenity.ID)
                    .FirstOrDefault();

                cb.Checked = true;
            }

            CalculatePrice();
        }

        private void CalculatePrice()
        {
            var checkedCB = flowLayoutPanel1.Controls
                .Cast<Control>()
                .Cast<CheckBox>()
                .Where(x => x.Enabled && x.Checked)
                .Select(x => x.Tag)
                .Cast<Amenity>()
                .ToList();

            var price = checkedCB.Count > 0 ? checkedCB.Sum(x => x.Price) : 0;
            price = price - previousPaid;
            var tax = price * 5 / 100;
            var totalPrice = price + tax;

            lblItemSelected.Text = $"${price:0}";
            lblDutiesAndTax.Text = $"${tax:0}";
            lblPayable.Text = $"${totalPrice:0}";
        }

        private void Cb_Click(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bookingReference = textBox1.Text.Trim();

            if(bookingReference.Equals(""))
            {
                MessageBox.Show("Please fill your booking reference!");
            }
            else
            {
                var flights = entities.Tickets
                    .Where(x => x.BookingReference.Equals(bookingReference) && x.Confirmed)
                    .ToList()
                    .Where(x => DateTime.Now <= (x.Schedule.Date + x.Schedule.Time).AddDays(-1))
                    .Select(x => new
                    {
                        Ticket = x,
                        Display = $"{x.Schedule.FlightNumber}, {x.Schedule.Route.Airport.IATACode}-{x.Schedule.Route.Airport1.IATACode}, " +
                                  $" {x.Schedule.Date.ToString("dd/MM/yyyy")}, {x.Schedule.Time.ToString(@"hh\:mm")}"
                    }).ToList();

                comboBox1.DisplayMember = "Display";
                comboBox1.ValueMember = "Ticket";
                comboBox1.DataSource = flights;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your flights!");
            }
            else
            {
                ticket = comboBox1.SelectedValue as Ticket;

                lblFullName.Text = $"{ticket.Firstname} {ticket.Lastname}";
                lblPassportNumber.Text = ticket.PassportNumber;
                lblCabinClass.Text = ticket.CabinType.Name;

                previousPaid = ticket.AmenitiesTickets.Count() > 0 ? ticket.AmenitiesTickets.Sum(x => x.Price) : 0;
                LoadAmenities(ticket);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var checkedAmenities = flowLayoutPanel1.Controls
                .Cast<Control>()
                .Cast<CheckBox>()
                .Where(x => x.Enabled && x.Checked)
                .Select(x => x.Tag)
                .Cast<Amenity>()
                .ToList();

            var lastPurchaseAmenities = ticket.AmenitiesTickets
                .Select(x => x.Amenity)
                .ToList();

            var checkedAmenitiesId = checkedAmenities.Select(x => x.ID).ToList();
            var lastPurchaseAmenitiesId = lastPurchaseAmenities.Select(x => x.ID).ToList();

            var newPurchaseAmenities = checkedAmenities
                .Where(x => !lastPurchaseAmenitiesId.Contains(x.ID))
                .ToList();

            var canceledAmenities = lastPurchaseAmenities
                .Where(x => !checkedAmenitiesId.Contains(x.ID))
                .ToList();

            var newAmenitiesTickets = new List<AmenitiesTicket>();
            foreach (var amenity in newPurchaseAmenities)
            {
                AmenitiesTicket amenitiesTicket = new AmenitiesTicket()
                {
                    TicketID = ticket.ID,
                    AmenityID = amenity.ID,
                    Price = amenity.Price
                };
                newAmenitiesTickets.Add(amenitiesTicket);
            }

            if(newAmenitiesTickets.Count > 0)
            {
                entities.AmenitiesTickets.AddRange(newAmenitiesTickets);
                entities.SaveChanges();
            }

            var deletedAmenitiesTickets = new List<AmenitiesTicket>();
            foreach (var amenity in canceledAmenities)
            {
                AmenitiesTicket amenitiesTicket = entities.AmenitiesTickets
                    .Where(x => x.TicketID == ticket.ID && x.AmenityID == amenity.ID)
                    .FirstOrDefault();

                entities.AmenitiesTickets.Remove(amenitiesTicket);
                entities.SaveChanges();
            }

            MessageBox.Show("Success!");

            previousPaid = ticket.AmenitiesTickets.Count() > 0 ? ticket.AmenitiesTickets.Sum(x => x.Price) : 0;
            LoadAmenities(ticket);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuForm form = new MenuForm();
            form.Show();
            this.Close();
        }
    }
}
