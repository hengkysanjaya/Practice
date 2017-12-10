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

namespace WindowsFormsApplication6
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
            string[] arr = { "sample.txt", "sample1.TXT", "sample.test.pdf", "sample1.PDF", "sample.xml", "sample2.txt", "sample3.txt" };
            //var egrp = arr.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
            //         .GroupBy(x => x, (ext, extCnt) => new
            //         {
            //             Extension = ext,
            //             Count = extCnt.Count()
            //         });

            var egrp = arr.Select(x => Path.GetExtension(x).TrimStart('.').ToLower())
                .GroupBy(x => x)
                .Select(x => new
                {
                    Extension = x.Key,
                    Count = x.Count()
                });

            foreach (var v in egrp)
            {   
                string a= string.Format("{0} File(s) with {1} Extension ", v.Count, v.Extension);
                MessageBox.Show(a);
            }

            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = db.RegistrationEvents.GroupBy(x => x.EventId ,(a,b)=> new
            {
                
            });
                
                
        }
    }
}
