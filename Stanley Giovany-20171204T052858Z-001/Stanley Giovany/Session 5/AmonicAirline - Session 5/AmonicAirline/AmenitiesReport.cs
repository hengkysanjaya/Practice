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
    public partial class AmenitiesReport : Form
    {
        session5Entities entities = new session5Entities();

        public AmenitiesReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            DateTime end = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

            if(end < start)
            {
                MessageBox.Show("End date must be same day or after the start date!");
            }
            else
            {
                var schedules = entities.Schedules.ToList()
                    .Where(x => x.Date + x.Time >= start && x.Date + x.Time <= end)
                    .ToList();

                string flightId = textBox1.Text.Trim();

                if(!flightId.Equals(""))
                {
                    schedules = schedules.Where(x => x.FlightNumber.Equals(flightId)).ToList();
                }

                var confirmedTickets = schedules
                    .Where(x => x.Confirmed)
                    .SelectMany(x => x.Tickets)
                    .Where(x => x.Confirmed)
                    .ToList();
                
                var implicitAmenities = confirmedTickets
                    .Select(x => x.CabinType)
                    .Distinct()
                    .SelectMany(x => x.Amenities)
                    .Distinct()
                    .ToList();

                var purchasedAmenities = confirmedTickets
                    .SelectMany(x => x.AmenitiesTickets)
                    .Select(x => x.Amenity)
                    .Distinct()
                    .ToList();

                var uniqueAmenities = new List<Amenity>(implicitAmenities);
                uniqueAmenities.AddRange(purchasedAmenities);
                uniqueAmenities = uniqueAmenities.Distinct().ToList();

                var reportData = confirmedTickets
                    .GroupBy(x => x.CabinType)
                    .Select(x => new
                    {
                        CabinTypeId = x.Key.ID,
                        Amenities = x.Key.Name,
                        Needed = uniqueAmenities
                                    .Select(y => new
                                    {
                                        Amenity = y,
                                        Count = x.ToList().Select(z => z.CabinType)
                                                    .SelectMany(z => z.Amenities)
                                                    .Where(z => z.ID == y.ID)
                                                    .Count() +
                                                x.ToList().SelectMany(z => z.AmenitiesTickets)
                                                    .Where(z => z.AmenityID == y.ID)
                                                    .Count()
                                    }).ToList()
                    }).ToList();

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = reportData;
                dataGridView1.Columns["CabinTypeId"].Visible = false;

                for (int i = 0; i < uniqueAmenities.Count; i++)
                {
                    DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
                    txtCol.HeaderText = uniqueAmenities[i].Service;
                    txtCol.Name = uniqueAmenities[i].ID.ToString();
                    dataGridView1.Columns.Add(txtCol);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var cabinTypeId = (int)dataGridView1.Rows[i].Cells["CabinTypeId"].Value;
                    var data = reportData.Where(x => x.CabinTypeId == cabinTypeId).FirstOrDefault();

                    for (int j = 0; j < data.Needed.Count; j++)
                    {
                        Amenity amenity = data.Needed[j].Amenity;
                        string column = amenity.ID.ToString();
                        dataGridView1.Rows[i].Cells[column].Value = data.Needed[j].Count;
                    }
                }
            }
        }
    }
}
