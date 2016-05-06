using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartixGraph;
namespace 圖論_Floyd算法
{
    class Program
    {
        static Martix g = new Martix(5);

        static void Main(string[] args)
        {
            Console.WriteLine("Statr Initialization Process , Input graph info (link input,no direct)");
            for (int i = 0; i < g.Count * g.Count; i++)
            {
                string[] s = Console.ReadLine().Split(' ');
                try
                {
                    if (s.Length == 1 && s[0].CompareTo("END") == 0)
                        break;
                    int v1 = Int32.Parse(s[0]);
                    int v2 = Int32.Parse(s[1]);
                    int w = Int32.Parse(s[2]);

                    g[v1][v2] = w;
                    g[v2][v1] = w;
                }
                catch
                {
                    Console.WriteLine("Excepted Data!");
                }
            }


        }
        static void Floyd(Martix g, out int[][] p, out int[][] d)
        {
            
        }
    }
}
