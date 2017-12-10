﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Md5_Review2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Hash(textBox1.Text));
        }
        
        private string Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] byt = md5.Hash;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < byt.Length; i++)
            {
                sb.Append(byt[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] data = { "a", "b", "c", "d", "e" };
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat("{0:D}",data[i].ToString());
            }

            MessageBox.Show(sb.ToString());
        }
    }
}