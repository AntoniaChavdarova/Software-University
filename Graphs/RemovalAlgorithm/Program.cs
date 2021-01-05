using System;
using System.Collections.Generic;
using System.Linq;

namespace RemovalAlgorithm
{
    class Program
    {
        private static Dictionary<string , List<string>> graph;
        private static Dictionary<string , int> dependencies;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            dependencies = ExtractDependencies();
            var sorting = TopologicalSorting();

            if(sorting == null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {String.Join(", " , sorting)}");
            }
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(v => v.Value == 0);

                if(string.IsNullOrEmpty(nodeToRemove.Key) || string.IsNullOrWhiteSpace(nodeToRemove.Key))
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = graph[node];

                sorted.Add(node);

                foreach (var child in children)
                {
                    dependencies[child] -= 1;
                }

                dependencies.Remove(nodeToRemove.Key);
            }

            if(dependencies.Count > 0)
            {
                return null;
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 1);
                    }
                    else
                    {
                        result[child] += 1;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n )
        {
            var graphResult = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->" , StringSplitOptions.RemoveEmptyEntries);

                var key = parts[0].Trim();

                if(parts.Length == 1)
                {
                    graphResult[key] = new List<string>();
                }
                else
                {
                    var children = parts[1]
                        .Trim()
                        .Split(", ").ToList();

                    graphResult[key] = children;

                }
               
            }

            return graphResult;
        }
    }
}