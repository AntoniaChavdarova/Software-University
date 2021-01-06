using System;
using System.Collections.Generic;

namespace CyclesInGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycle;

        static void Main(string[] args)
        {
            
            graph = ReadGraph();
            visited = new HashSet<string>();
            cycle = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine("Acyclic: No");
                    return;
                }    
               
            }

            Console.WriteLine("Acyclic: Yes");
           
        }

        private static void DFS(string node)
        {
            if (cycle.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

           

            visited.Add(node);
            cycle.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycle.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var result = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splitted = input.Split("-");
                var node = splitted[0];
                var child = splitted[1];

                if (!result.ContainsKey(node))
                {
                    result.Add(node, new List<string>());
                }

                if (!result.ContainsKey(child))
                {
                    result.Add(child, new List<string>());
                }

                result[node].Add(child);

                input = Console.ReadLine();
            }


            return result;
        }
    }
}
