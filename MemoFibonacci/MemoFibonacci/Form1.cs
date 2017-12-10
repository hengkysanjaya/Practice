using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoFibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            memo[0] = 0;
            memo[1] = 1;
            MessageBox.Show(Fibo(10000).ToString());
        }

        int[] memo = new int[1000000];
        private int Fibo(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            memo[n - 2] = memo[n - 2] == 0 ? Fibo(n - 2) : memo[n - 2];
            memo[n - 1] = memo[n-1] == 0 ? Fibo(n - 1) : memo[n - 1];
            return memo[n-1] + memo[n-2];
            
        }
    }
}
