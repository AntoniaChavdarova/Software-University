using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BreakCycles
{
    public class Edge
     {
        public Edge(string first , string sec)
        {
            this.First = first;
            this.Second = sec;
        }
        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string ToStringReversed()
        {
             return $"{this.Second} - {this.First}";
        }
    }
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            int n = int.Parse(Console.ReadLine());

            ProcessInput(n);

            edges = edges.OrderBy(x => x.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var blackListed = new HashSet<string>();

            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                

                if(HasPath(first , second))
                {
                    if (blackListed.Contains(edge.ToString()))
                    {
                        continue;
                    }
                    removedEdges.Add(edge);
                    blackListed.Add(edge.ToStringReversed());
                }
                else
                {
                    graph[first].Add(second);
                   
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var item in removedEdges)
            {
                Console.WriteLine($"{item.First} - {item.Second}");
            }
        }

        private static bool HasPath(string source , string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string> { source };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == destination)
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

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var node = line[0];
                var children = line[1].Split();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
