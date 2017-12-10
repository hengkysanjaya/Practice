using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace session5review
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        decimal totalPaidBefore = 0;
        decimal totalPay = 0;
        int itemSelected = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = db.Tickets.Where(x => x.BookingReference == textBox1.Text
                    //&& (x.Schedule.Date - DateTime.Now).TotalHours >= 24
                    ).ToList()
                    .Select(x => new
                    {
                        Value = x,
                        Display = $"{x.Schedule.FlightNumber},{x.Schedule.Route.Airport.IATACode}-{x.Schedule.Route.Airport1.IATACode}, {x.Schedule.Date.ToString("MM/dd/yyyy")}, {x.Schedule.Time.ToString("hh\\:mm")}"
                    }).ToList();
            comboBox1.DisplayMember = "Display";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = q;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }

            flowLayoutPanel1.Controls.Clear();
            var ticket = (Ticket)comboBox1.SelectedValue;


            var q = db.Tickets.Where(x => x.ID == ticket.ID).FirstOrDefault();
            label5.Text = $"{q.Firstname} {q.Lastname}";
            label8.Text = q.PassportNumber;
            label6.Text = q.CabinType.Name;



            var q2 = db.AmenitiesTickets.Where(x => x.TicketID == ticket.ID);
            totalPaidBefore = q2.Sum(x => x.Price);

            var listAmenitiesBookedId = q2.Select(x => x.AmenityID).ToList();

            var amenities = db.AmenitiesCabinTypes.Where(x => x.CabinTypeID == ticket.CabinTypeID).ToList();
            foreach (var a in amenities)
            {
                var amenity = a.Amenity;

                CheckBox chk = new CheckBox();

                chk.AutoSize = true;
                chk.Location = new System.Drawing.Point(13, 13);
                chk.Name = "checkBox1";
                chk.Size = new System.Drawing.Size(80, 17);
                chk.TabIndex = 0;
                chk.UseVisualStyleBackColor = true;


                decimal price = amenity.Price;
                string ket = price == 0 ? "(Free)" : price.ToString();
                chk.Text = amenity.Service + $" {ket}";

                if (price == 0)
                {
                    itemSelected += 1;
                    chk.Checked = true;
                    chk.Enabled = false;
                }
                else if (listAmenitiesBookedId.Contains(amenity.ID))
                {
                    chk.Checked = true;
                    itemSelected += 1;
                }


                chk.CheckedChanged += Chk_CheckedChanged;
                chk.Tag = amenity;

                flowLayoutPanel1.Controls.Add(chk);
            }
            Count(true);
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;

            var amenity = (Amenity)chk.Tag;

            if (chk.Checked)
            {
                totalPay += amenity.Price;
                itemSelected += 1;
            }
            else
            {
                totalPay -= amenity.Price;
                itemSelected -= 1;
            }
            Count(false);
        }

        private void Count(bool first)
        {
            if (first) totalPay = totalPaidBefore;

            label12.Text = itemSelected.ToString();
            decimal total = totalPay - totalPaidBefore;

            decimal diskon = 105 / 100 * total;
            label13.Text = Math.Floor(diskon).ToString();
            label14.Text = Math.Floor(total).ToString();
        }
    }
}
