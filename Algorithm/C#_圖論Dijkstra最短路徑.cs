using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartixGraph;
namespace 圖論_Dijkstra_最短路徑算法
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
            int[] p, d;
            Dijkstra_Algorithm(g, 0,out p,out d);
            Console.WriteLine("Output");
            //輸出路徑值
            foreach(var a in d)
                Console.Write("{0} ",a);
            Console.WriteLine();
            //輸出來源節點
            foreach (var a in p)
                Console.Write("{0} ", a);
            Console.ReadKey();
        }
        /// <summary>
        /// Dijkstra算法中,p陣列記錄該點的最短距離Weight是多少,而d陣列記錄該Weight是來自於哪個節點
        /// </summary>
        static void Dijkstra_Algorithm(Martix g,int v0,out int[] p,out int[] d)
        {
            bool[] final = new bool[g.Count]; //是否已經求得最短路徑
            d = new int[g.Count];
            p = new int[g.Count];
            //Initialization
            for (int v = 0; v < g.Count; v++)
            {
                final[v] = false;
                d[v] = g[v0][v];
                p[v] = 0;
            }
            d[v0] = 0;          //起頭節點路徑0
            final[v0] = true;   //起頭已經找到
            for (int v = 1; v < g.Count; v++)
            {
                int min = 65535;
                int k = 0;      
                //找尋離v0最近的頂點
                for(int w = 0;w < g.Count;w++)
                    if(!final[w] && d[w] < min)
                    {
                        k = w;
                        min = d[w];
                    }
                final[k] = true;
                //修正找到的節點四周的最短路徑
                for (int w = 0; w < g.Count; w++)
                    if (!final[w] && (min + g[k][w] < d[w]))
                    {
                        d[w] = min + g[k][w];
                        p[w] = k;
                    }
            }
        }
    
    }
}
