using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDBindingSource_Review
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            studentBindingSource.DataSource = db.Students.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student()
            {
                NISN = nISNTextBox.Text,
                Name = nameTextBox.Text,
                Birthplace = birthplaceTextBox.Text,
                Date_of_Birth = date_of_BirthDateTimePicker.Value,
                Address = addressTextBox.Text,
                Gender = genderTextBox.Text[0],
                Class = "2b",
                Phone_Number = "123445567",
            };
            
            studentBindingSource.Add(s);
            db.Students.InsertOnSubmit(s);
        }

        public void Clear()
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
                if(ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Value = DateTime.Now;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s = (Student)studentBindingSource.Current;
            db.Students.DeleteOnSubmit(s);
            studentBindingSource.RemoveCurrent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
