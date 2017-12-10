using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input n digit");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Input m number");
            int m = int.Parse(Console.ReadLine());

            int a;
            for (int i = 1; i <= n; i++)
            {
                a = i % m;
                a = a == 0 ? m : a;
                Console.Write(a + " "); 
            }
            Console.ReadLine();
        }
    }
}
