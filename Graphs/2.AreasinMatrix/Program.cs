using System;
using System.Collections.Generic;

namespace _2.AreasinMatrix
{
    public class Node
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
    class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            graph = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];

            //area - count
            var areas = new SortedDictionary<char, int>();
            var totalAreas = 0;


            for (int r = 0; r < graph.GetLength(0); r++)
            {
                for (int c = 0; c < graph.GetLength(1); c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }

                    DFS(r, c);
                    totalAreas += 1;
                    var key = graph[r, c];

                    if (areas.ContainsKey(key))
                    {
                        areas[key] += 1;
                    }
                    else
                    {
                        areas.Add(key, 1);
                    }
                }
            }

            Console.WriteLine($"Areas: {totalAreas}");
            foreach (var item in areas)
            {
                Console.WriteLine($"Letter '{item.Key}' -> {item.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            
           visited[row, col] = true;

            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();

            //row + 1 , col;

            if(Validate(row + 1, col) &&
            IsChild(row  , col , row + 1 , col) && 
            !IsVisited(row + 1, col))
            {
                children.Add(new Node { Row = row + 1, Col = col });
            }

            if (Validate(row - 1, col) &&
            IsChild(row, col, row - 1, col) &&
            !IsVisited(row - 1, col))
            {
                children.Add(new Node { Row = row - 1, Col = col });
            }

            if (Validate(row , col + 1) &&
            IsChild(row, col, row, col + 1) &&
            !IsVisited(row, col + 1))
            {
                children.Add(new Node { Row = row, Col = col + 1 });
            }

            if (Validate(row, col - 1) &&
           IsChild(row, col, row, col - 1) &&
           !IsVisited(row, col - 1))
            {
                children.Add(new Node { Row = row, Col = col - 1 });
            }

            return children;

        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow , int childCol)
        {
            return graph[parentRow, parentCol] == graph[childRow, childCol];
        }

        private static bool Validate(int row, int col)
        {
            return row >= 0 && row < graph.GetLength(0) && col >= 0 && col < graph.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            return matrix;
        }
    }
}
