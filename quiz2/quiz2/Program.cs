using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Length Fibonacci : ");
            int n = int.Parse(Console.ReadLine());

            // 0 1 1 2 3 5 8 13 21
            for (int i = 0; i < n; i++)
            {
                Console.Write(Fibonacci(i).ToString() + " ");
            }

            Console.ReadLine();
        }

        public static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            // 0 1 1 2 3 5
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
