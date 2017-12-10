using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                List<string> data = new List<string>();
                for (int j = 0; j < n; j++)
                {
                    string text = Console.ReadLine().ToLower();
                    if (text.Length == m)
                    {
                        data.Add(text);
                    }
                }
                string word = Console.ReadLine().ToLower();

                int Possible = 0;
                for (int z = 0; z < data.Count; z++)
                {
                    var a = data[z].ToArray();
                    //catt
                    //aata
                    //tatc

                    // word = cat

                    var pecahan = word.ToArray();

                    bool yes = true;
                    for (int y = 0; y < pecahan.Length; y++)
                    {                        
                        var q = a.Where(x => x == pecahan[y]).Count();
                        if (q == 0)
                        {
                            yes = false;
                        }
                    }

                    if (yes)
                    {

                        int tempN = 0;
                        int qty = 0;
                        for (int y = 0; y < pecahan.Length; y++)
                        {
                            var q = a.Count(x => x == pecahan[y]);
                            if (q > 1)
                            {
                                qty += 1;
                                //Console.Write("q : "+q+"\nJumlah : "+tempN);
                                tempN += q;
                            }
                        }
                        tempN *= qty;
                        Possible += tempN;
                    }
                    
                }
                Console.WriteLine("Case " + (i + 1) + " : " + Possible);
            }
            Console.ReadLine();
        }
    }
}
