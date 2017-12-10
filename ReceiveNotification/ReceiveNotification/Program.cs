using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.Enums;
using TableDependency.EventArgs;
using TableDependency;

namespace ReceiveNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            var _con = @"Data Source=DESKTOP-RACLV28\SQLEXPRESS;Initial Catalog=EsemkaAirLineHengky;Integrated Security=True";
            var mapper = new ModelToTableMapper<Pesawat>();
            mapper.AddMapping(c => c.IDPesawat, "IDPesawat");
            mapper.AddMapping(c => c.NamaPesawat, "NamaPesawat");

            // Here - as second parameter - we pass table name: this is necessary because the model name is 
            // different from table name (Pesawat vs Pesawats)
            using (var dep = new SqlTableDependency<Pesawat>(_con, "Pesawat", mapper))
            {
                dep.OnChanged += Changed;
                dep.Start();

                Console.WriteLine("Press a key to exit");
                Console.ReadKey();

                dep.Stop();
            }
        }
        static void Changed(object sender, RecordChangedEventArgs<Pesawat> e)
        {
            var changedEntity = e.Entity;
            Console.WriteLine("DML operation: " + e.ChangeType);
            Console.WriteLine("ID: " + changedEntity.IDPesawat);
            Console.WriteLine("Name: " + changedEntity.NamaPesawat);
            
        }
    }
    class Pesawat
    {
        public string IDPesawat { get; set; }
        public string NamaPesawat { get; set; }
    }
}
