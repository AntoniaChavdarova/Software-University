using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            var matrix = new char[row, col];


            for (int r = 0; r < row; r++)
            {
                var line = Console.ReadLine();

                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            var directions = new List<char>();
            FindAllPaths(matrix, 0, 0, directions, '\0');



        }

        private static void FindAllPaths(char[,] matrix, int row, int col, List<char> directions, char direction)
        {
            if (IsOutside(matrix, row, col) || IsWall(matrix, row, col) || IsVisited(matrix, row, col))
            {
                return;
            }

            directions.Add(direction);

            if (IsSolution(matrix, row, col))
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;

            }

            matrix[row, col] = 'v';

            FindAllPaths(matrix, row, col + 1, directions, 'R');
            FindAllPaths(matrix, row + 1, col, directions, 'D');
            FindAllPaths(matrix, row, col - 1, directions, 'L');
            FindAllPaths(matrix, row - 1, col, directions, 'U');

            directions.RemoveAt(directions.Count - 1);
            matrix[row, col] = '-';

        }

        private static bool IsSolution(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsVisited(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsWall(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(char[,] matrix, int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }




    }
}

