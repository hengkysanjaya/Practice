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

namespace GuidGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "Image Files|*.jpg;*.png;*.jpeg";
                if(op.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = op.FileName;
                    pictureBox1.Image = Image.FromFile(op.FileName);
                }
            }
        }

        string defaultPath = Application.StartupPath;
        private void button2_Click(object sender, EventArgs e)
        {
            string myPath = defaultPath + @"\Image\";
            Directory.CreateDirectory(myPath);
            File.Copy(textBox1.Text, myPath + Guid.NewGuid()+Path.GetExtension(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            MessageBox.Show(Path.DirectorySeparatorChar.ToString());
        }
    }
}
