using System;
using System.Collections.Generic;

namespace _2.SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 1, 4, 2 };
            var target = 6;

            var sums = GetAllSums(nums);

            Console.WriteLine(String.Join(" " , sums));
            Console.WriteLine(sums.Contains(target));
        }

        private static HashSet<int> GetAllSums(int[] nums)
        {
            var sums = new HashSet<int> { 0 };

            foreach (var num in nums)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return sums;
        }
    }
}
