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

namespace listView_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Data> listData = new List<Data>();
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] path = Directory.GetFiles(Application.StartupPath + @"\Image");
            int i = 1;
            foreach (var a in path)
            {
                listData.Add(new Data() { Path = a, Title = $"Title {i}" });
                i++;
            }
            
            listView1.View = View.Details;
            listView1.Columns.Add("Gambar",150);
            listView1.Columns.Add("Title",150);

            ImageList listImage = new ImageList();
            listImage.ImageSize = new Size(50, 50);

            listData.Where(x=>x.Path!="").ToList().ForEach(x => listImage.Images.Add(Image.FromFile(x.Path)));
          
            listView1.SmallImageList = listImage;
            i = 0;
            foreach(var a in listData)
            {
                ListViewItem item = new ListViewItem("", i);
                item.SubItems.Add(a.Title);
                listView1.Items.Add(item);
                i++;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
    class Data
    {
        public string Path { get; set; }
        public string Title { get; set; }
    }
}
