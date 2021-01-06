using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RoadReconstruction
{
    public class Edge : IEqualityComparer<Edge>
    {
        public Edge(int first, int sec)
        {
            this.First = first;
            this.Second = sec;
        }
        public int First { get; set; }
        public int Second { get; set; }

       

        public bool Equals([AllowNull] Edge x, [AllowNull] Edge y)
        {
            throw new NotImplementedException();
        }

       

        public int GetHashCode([DisallowNull] Edge obj)
        {
            throw new NotImplementedException();
        }

       
    }
        class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<Edge> edges;
        
        static void Main(string[] args)
        {
            int nNodes = int.Parse(Console.ReadLine());
            int nEdges = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            edges = new HashSet<Edge>();

            ProcessInput( nNodes ,nEdges);
            var importantEdges = new HashSet<Edge>();
            var blackEdges = new HashSet<string>();

           
                

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);

                if(!HasPath(first , second))
                {
                    importantEdges.Add(edge);
                }
                else
                {
                    graph[first].Add(second);
                }

            
            }

            Console.WriteLine($"Important streets:");

            foreach (var item in importantEdges)
            {
                var current = $"{item.First} - {item.Second}";

                if (blackEdges.Contains(current))
                {
                    continue;
                }

                Console.WriteLine($"{item.First} {item.Second}");

                var reversed = $"{item.Second} - {item.First}";
                blackEdges.Add(reversed);

               
            }
        }

        private static void ProcessInput(int n, int e)
        {
            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(line[0]);
                var children = int.Parse(line[1]);

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<int>());
                }

                graph[node].Add(children);

                if (!graph.ContainsKey(children))
                {
                    graph.Add(children, new List<int>());
                }

                graph[children].Add(node);

            }

            foreach (var item in graph.Keys)
            {
                foreach (var child in graph[item])
                {

                    edges.Add(new Edge(item, child));
                }
            }
            
        }

        private static bool HasPath(int source, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);

            var visited = new HashSet<int> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return false;
        }

       
    }
}
