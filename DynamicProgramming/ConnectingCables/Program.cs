using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var positions = new int[nums.Length];

            for (int r = 0; r < nums.Length ; r++)
            {
                positions[r] = r + 1;
            }
            var table = new int[nums.Length + 1, nums.Length + 1];

            

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if(nums[r - 1] == positions[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }


            Console.WriteLine($"Maximum pairs connected: {table[nums.Length , nums.Length]}");

            var row = nums.Length;
            var col = nums.Length;

            var pairs = new List<int>();

            while (row > 0 && col > 0)
            {
                if (nums[row - 1] == positions[col - 1])
                {
                    pairs.Add(nums[row - 1]);
                    row -= 1;
                    col -= 1;

                } else if (table[row - 1 , col] > table[row , col - 1])
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            Console.WriteLine(String.Join(" " , pairs));
        }
    }
}
