using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBindingSource
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        private void button1_Click(object sender, EventArgs e)
        {   
            studentBindingSource.EndEdit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentBindingSource.DataSource = db.Students.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            studentBindingSource.RemoveCurrent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // studentBindingSource.CancelEdit();
            //Clear();
            Student s = new Student()
            {
                NISN = "1111",
                Name = "Hengky",
                Date_of_Birth = DateTime.Now,
                Gender = 'M',
                Address = "Jalan Jalan",
                Phone_Number = "082108109",
                Birthplace = "",
                Class = "2d"
                
            };
            studentBindingSource.Add(s);
            db.Students.InsertOnSubmit(s);
        }

        public void Clear()
        {
            foreach(Control kontrol in this.Controls)
            {
                if(kontrol is TextBox)
                {
                    kontrol.Text = "";
                }
                if(kontrol is DateTimePicker)
                {
                    ((DateTimePicker)kontrol).Value = DateTime.Now;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
