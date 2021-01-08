using System;

namespace WordDiffrence
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var table = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                table[r, 0] = r;     
            }
            for (int c = 1; c < table.GetLength(1); c++)
            {
                table[0, c] = c;
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {

                    if(str1[row - 1] == str2[col - 1])
                    {
                        table[row, col] = table[row - 1, col - 1];
                    }
                    else
                    {
                        table[row, col] = Math.Min(table[row - 1, col], table[row, col - 1]) + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {table[str1.Length , str2.Length]}");
        }
    }
}
