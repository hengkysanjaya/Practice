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
    public partial class AmenitiesReport : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public AmenitiesReport()
        {
            InitializeComponent();
        }

        private void AmenitiesReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = db.AmenitiesTickets.Where(x =>
                        (x.Ticket.Schedule.FlightNumber == textBox1.Text || textBox1.Text == "")
                        &&
                        (x.Ticket.Schedule.Date >= dateTimePicker1.Value && x.Ticket.Schedule.Date <= dateTimePicker2.Value)
                        ).ToList().Select(x=> new ReportAmenities
                        {
                            AmenitiesName = x.Amenity.Service,
                            Class = x.Ticket.CabinType.Name,
                            Value = 1
                        }).ToList();

            ReportAmenitiesBindingSource.DataSource = q;
            this.reportViewer1.RefreshReport();
        }
    }
    public class ReportAmenities
    {
        public string AmenitiesName { get; set; }
        public string Class { get; set; }
        public int Value { get; set; }
    }
}
