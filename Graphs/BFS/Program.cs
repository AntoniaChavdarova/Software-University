using System;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>
            {
                {1 , new List<int>{19 , 21 , 14} },
                {19 , new List<int>{7 , 12 , 31 , 21} },
                {21 , new List<int>{14} },
                {14 , new List<int>{23 , 6} },
                {7 , new List<int>{1} },
                {12 , new List<int>() },
                {31 , new List<int>{21} },               
                {23 , new List<int>{21} },
                {6 , new List<int>() },

            };

            visited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                BFS(node);
            }
        }

        private static void BFS(int startNode)
        {
            if (visited.Contains(startNode))
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node);

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
        }
    }
}
