using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Size = new Size(50, 50);
                btn.Margin = new Padding(10, 10, 15, 10);
                flowLayoutPanel1.Controls.Add(btn);
            }

            propertyGrid1.SelectedObject = new Header();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {       
            label1.Text = vScrollBar1.Value.ToString();
            button1.Location = new Point(13, 12 - vScrollBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newGuid = Guid.NewGuid().ToString();
            MessageBox.Show(newGuid);
            MessageBox.Show(new string('+',10));

            
        }
    }
    class Header
    {
        public String Name { get; set; }
        public string Text { get; set; }
        public List<Item> listItem { get; set; }
        public Header()
        {
            listItem = new List<Item>();
        }

    }
    class Item
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
