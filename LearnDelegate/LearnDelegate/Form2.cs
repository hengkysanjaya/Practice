﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LearnDelegate.Form1;

namespace LearnDelegate
{
    public partial class Form2 : Form
    {   
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public event test callBack;

        private void button1_Click(object sender, EventArgs e)
        {
            callBack();
        }
    }
}
