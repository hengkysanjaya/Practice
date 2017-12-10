using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INC2015A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibo(5));
            Console.ReadLine();
            return;


            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int a=0;
            for (int i = 1; i <= M; i++)
            {
                if (F(i, N) ==-1)
                {
                    a++;
                }
            }
            Console.WriteLine(a);
            Console.ReadLine();
            //int Ncase = int.Parse(Console.ReadLine());
            //for (int i = 1; i <= Ncase; i++)
            //{
            //    int digit = int.Parse(Console.ReadLine());
            //    List<string> test = Console.ReadLine().Split(' ').ToList();
            //    var q = test.Where(x => int.Parse(x) < 60);
            //    Console.WriteLine($"Case {i} : {q.Count()}");
            //}
            //Console.ReadLine();
        }
        public static int fibo(int n,int m)
        {
            int a = 1;
            int b = 1;
            int c = 0;

            int total = 0;
            int found = 0;
            for (int i = 1; i < n; i++)
            {
                c = a + b;
                a = b;
                b = c;
                total += b;

                if(a == m || b == m || c == m)
                {
                    found++;
                }
            }
            // 1 1 2 3
            return found;
        }
        public static int F(int n, int b)
        {
            if (n <= 1) return n;
            if (n == b) return -1;
            return F(n - 1,b) + F(n - 2,b);
        }
    }
}

