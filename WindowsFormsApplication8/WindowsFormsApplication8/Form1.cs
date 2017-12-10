using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
         string[,] array = new string[,]
            {
                {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
                {"#","#","#","#","#","#","#","#","#","#","#","#",".",".",".",".","#"},
                {"#","#",".",".",".",".",".",".",".","c",".","#","#","#",".",".","#"},
                {"#","#","#","#","#",".",".",".",".",".",".","#",".","#",".",".","#"},
                {"#",".","#",".","#","#","#","#","#","#","#","#",".","#",".",".","#"},
                {"#","#","#",".",".",".","#",".",".","b","#",".",".","#",".",".","#"},
                {"#","#",".","a",".","#",".",".",".","#",".",".",".","#","#","#","#"},
                {"#","#","#","#","#",".","#",".","#","d","#","#","#",".",".","#","#"},
                {"#",".",".",".",".",".",".","#",".",".",".","e","#","x","x","#","#"},
                {"#",".","#",".",".",".",".","#","#","#","#","#","#","#","#","#","#"},
                {"#",".","#",".","x",".",".","#",".",".","#",".",".",".",".",".","#"},
                {"#",".","#","#","#","#","#","#",".","c","#",".",".",".",".",".","#"},
                {"#",".",".",".",".",".",".","#","#","#","#",".",".",".",".",".","#"},
                {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
            };
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public int Search(int x, int y)
        {
            if(array[x,y].ToString() != "#")
            {
                
            }

            return 0;
        }


    }
    class data
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
