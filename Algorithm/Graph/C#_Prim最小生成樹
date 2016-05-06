using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartixGraph;
using System.IO;
namespace 圖論_Prim_最小生成樹
{
    class Program
    {

        static Martix g = new Martix(8);

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
            Prim_Algorithm(g);
            Console.Read();
        }

        static void Prim_Algorithm(Martix g)
        {
            //宣告
            int[] lowcost = new int[g.Count];
            int[] adjvex = new int[g.Count];        //說明lowcost儲存的值來自哪個vertex
            //初始化
            for (int i = 0; i < g.Count; i++)
            {
                lowcost[i] = g[0][i];
                adjvex[i] = 0;
            }
            lowcost[0] = -1; 
            //主算法
            for(int i = 0;i < g.Count;i++){
                //找最小路徑
                int w = 65535,k = 0;
                for(int j = 0;j < g.Count;j++)
                    if (lowcost[j] != -1 && lowcost[j] < w)
                    {
                        w = lowcost[j];
                        k = j;
                    }
                //套用最小點
                if (k != 0)
                {
                    lowcost[k] = -1;
                    Console.WriteLine("登記 {0} - {1} w:{2}", adjvex[k], k,g[adjvex[k]][k]);
                }
                //更新lowcost
                for (int j = 0; j < g.Count; j++)                
                    if(g[k][j] < lowcost[j])
                    {
                        lowcost[j] = g[k][j];
                        adjvex[j] = k;
                    }          
            }
        }
    }
}
