using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDependency;
using TableDependency.SqlClient;

namespace ReceiveNotificationFromSqlServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            var connectionString = @"Data Source=DESKTOP-RACLV28\SQLEXPRESS;Initial Catalog=EsemkaAirLineHengky;Integrated Security=True";

            var mapper = new ModelToTableMapper<Pesawat>();
            mapper.AddMapping(c => c.IdPesawat, "IDPesawat");
            mapper.AddMapping(c => c.NamaPesawat, "NamaPesawat");

            using (var tableDependency = new SqlTableDependency<Pesawat>(connectionString, "Pesawat"))
            {
                tableDependency.OnChanged += TableDependency_OnChanged;
                tableDependency.OnError += TableDependency_OnError;

                tableDependency.Start();
                richTextBox1.Text = "Waiting for receiving notification..."+Environment.NewLine;
                tableDependency.Stop();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {
            throw e.Error;
        }

        private void TableDependency_OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<Pesawat> e)
        {
            //if (e.ChangeType != TableDependency.Enums.ChangeType.None)
            //{
                var changedEntity = e.Entity;
                richTextBox1.Text += $"DML Operation {e.ChangeType}" + Environment.NewLine;
                richTextBox1.Text += $"ID: { changedEntity.IdPesawat}" + Environment.NewLine;
                richTextBox1.Text += $"Name : {changedEntity.NamaPesawat}" + Environment.NewLine;
            //}
        }
    }

    class Pesawat
    {
        public string IdPesawat { get; set; }
        public string NamaPesawat { get; set; }
    }
}
