using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addPictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = System.Drawing.Color.Black;
                pb.Location = new System.Drawing.Point((i*100)+12, 12);
                pb.Name = "pictureBox1";
                pb.Size = new System.Drawing.Size(91, 69);
                pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pb.TabIndex = 0;
                pb.TabStop = false;

                this.Controls.Add(pb);
            }
        }
    }
}
