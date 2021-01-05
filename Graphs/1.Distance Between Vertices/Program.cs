using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Distance_Between_Vertices
{
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine().Split("-").Select(int.Parse).ToArray();

                var from = line[0];
                var to = line[1];

                var steps = ShortestPath(from, to);
                Console.WriteLine($"{{{from}, {to}}} -> {steps}");
            }
        }

        private static int ShortestPath(int from, int to)
        {
            var queue = new Queue<int>();
            queue.Enqueue(from);

            var steps = new Dictionary<int, int> { { from, 0 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == to)
                {
                    return steps[node];
                }

                foreach (var child in graph[node])
                {
                    if (!steps.ContainsKey(child))
                    {
                        queue.Enqueue(child);
                        steps[child] = steps[node] + 1;
                    }
                }
            }
            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var result = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var node = int.Parse(line[0]);

                if(line.Length == 1)
                {
                    result[node] = new List<int>();
                }
                else
                {
                    var children = line[1].Split()
                   .Select(int.Parse)
                   .ToList();

                    result[node] = (children);

                }


            }

            return result;
        }
    }
}
