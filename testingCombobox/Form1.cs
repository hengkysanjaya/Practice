using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testingCombobox
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
            var hotel = db.hotels.ToList();
            comboBox1.DisplayMember = "namahotel";
            comboBox1.ValueMember = "idhotel";
            comboBox1.DataSource = hotel;
            //dataGridView1.DataSource = arrivalCity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = comboBox1.SelectedItem as hotel;
            MessageBox.Show(q.kota.namakota);
        }
    }
}
