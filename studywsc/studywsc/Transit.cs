using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace studywsc
{
    public partial class Transit : core
    {
        public Transit()
        {
            InitializeComponent();
        }
        List<History> listHistory;
        History current;

        public Transit(List<History> listHistory,int Id)
        {
            InitializeComponent();
            this.listHistory = listHistory;
            current = listHistory.Where(x => x.ID == Id).FirstOrDefault();
        }
        

        private void Transit_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current.Reason = richTextBox1.Text;
            WriteHistory(listHistory);
            this.Close();
            new Main().Show();
        }
    }
}
