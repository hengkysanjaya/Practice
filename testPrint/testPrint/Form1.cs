using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;

namespace testPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        IEnumerator items;
        public void StartPrint()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            items = GetEnumerator();
            if (items.MoveNext())
            {
                pd.Print();
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            const int neededHeight = 200;
            int line = 0;
            // this will be called multiple times, so keep track where you are...
            // do your drawings, calculating how much space you have left on one page
            bool more = true;
            do
            {
                // draw your bars for item, handle multilple columns if needed
                var item = items.Current;
                line++;
                // in the ev.MarginBouds the width and height of this page is available
                // you use that to see if a next row will fit
                if ((line * neededHeight) < ev.MarginBounds.Height)
                {
                    break;
                }
                more = items.MoveNext();
            } while (more);
            // stop if there are no more items in your Iterator
            ev.HasMorePages = more;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
