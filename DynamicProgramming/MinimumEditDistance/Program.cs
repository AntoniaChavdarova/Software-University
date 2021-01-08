using System;

namespace MinimumEditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var replaceCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = row * deleteCost;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = col * insertCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    var cost = str1[row - 1] == str2[col - 1] ? 0 : replaceCost;

                    var delete = matrix[row - 1, col] + deleteCost;
                    var replace = matrix[row - 1, col - 1] + cost;
                    var insert = matrix[row, col - 1] + insertCost;

                    matrix[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }

            var result = matrix[str1.Length, str2.Length];
            Console.WriteLine($"Minimum edit distance: {result}");
        }

    }

}


