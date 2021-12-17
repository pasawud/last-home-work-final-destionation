using System;
using System.Collections.Generic;

namespace last_city
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("input amount city : ");
            int city = 0;
            city = int.Parse(Console.ReadLine());

            List<string> Cityname = new List<string>();

            Pathfinder matrix = new Pathfinder();
            matrix.V = city;

            for (int x = 0; x < city; x++)
            {
                Console.Write("input city name = ");
                string cityname = Console.ReadLine();
                Cityname.Add(cityname);
            }
            int[,] matrix2 = new int[city, city];

            for(int i = 0; i < city; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j)
                    {
                        matrix2[i, j] = 0;
                    }
                    else
                    {
                        Console.Write("input Distance : ");

                        int dis = int.Parse(Console.ReadLine());

                        int distant = dis;

                        if (dis == -1)
                        {
                            distant = 0;
                        }
                        matrix2[i, j] = distant;
                        matrix2[j, i] = distant;
                    }
                }
            }
            string last;
            int lastcity = 0;
            Console.Write("input last city you want to go : ");
            last = Console.ReadLine();

            for (int i =0; i < Cityname.Count; i++)
            {
                if (last == Cityname[i])
                {
                    lastcity = i;
                }
            }
            matrix.dijkstra(matrix2, 0, lastcity);
        }
    }
    class Pathfinder
    {
        public int V;
        int minDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }
        public void PrintSolution(int[] dist, int city)
        {
            Console.Write("{0}", dist[city]);
            Console.ReadLine();
        }
        public void dijkstra(int[,] graph, int src, int cityindex)
        {
            int[] dist = new int[V];

            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }
            dist[src] = 0;
            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }
            PrintSolution(dist, cityindex);
        }
    }
}
