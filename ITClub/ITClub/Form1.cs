using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITClub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Image = global::ITClub.Properties.Resources.Screenshot__1_;
            pb.Location = new System.Drawing.Point(10, 13);
            pb.Name = "pictureBox1";
            pb.Size = new System.Drawing.Size(112, 85);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pb.TabIndex = 0;
            pb.TabStop = false;
        }
    }
}
