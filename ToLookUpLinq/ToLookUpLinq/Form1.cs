using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToLookUpLinq
{
    public partial class Form1 : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = db.detailtransaksihotels.ToLookup(x => x.idhotel);
            foreach(var a in q)
            {
                foreach(var b in a)
                {
                   
                }
            }
            
            
        }
    }
}
