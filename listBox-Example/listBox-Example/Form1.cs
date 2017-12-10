using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace listBox_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            listBox1.MultiColumn = true;
            listBox1.ColumnWidth = 150;

            for (int i = 0; i < 20; i++)
            {
                listBox1.Items.Add($"test {i}");
            }


            // ----------------------------------------
            listView1.Columns.Add("ID");
            listView1.Columns.Add("Nama");
            listView1.Columns.Add("Kelas");

            ListViewItem item = new ListViewItem("1");
            item.SubItems.Add("Hengky");
            item.SubItems.Add("12 TKJ 1");
            listView1.Items.Add(item);



            listView2.Columns.Add("Gambar",250);
            listView2.Columns.Add("Title", 250);
            listView2.View = View.Details;

            ImageList listImage = new ImageList();
            listImage.ImageSize = new Size(50, 50);
            string[] path = Directory.GetFiles(Application.StartupPath + @"\Image");
            foreach(var a in path)
            {
                listImage.Images.Add(Image.FromFile(a));
            }
            listView2.SmallImageList = listImage;
            
            //ListViewItem item2 = new ListViewItem("",0);
            //item2.SubItems.Add("hai hai hai");
            //listView2.Items.Add(item2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "All data must be filled");
            errorProvider1.SetError(textBox2, "All data must be filled");
        }
    }
}
