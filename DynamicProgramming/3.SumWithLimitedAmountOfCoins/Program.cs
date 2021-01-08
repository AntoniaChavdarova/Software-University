using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SumWithLimitedAmountOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            var count = GetCount(nums , target);
            Console.WriteLine(count);
        }

        private static int GetCount(int[] nums, int target)
        {
            var sums = new HashSet<int> { 0 };
            var count = 0;

            foreach (var num in nums)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    newSums.Add(newSum);


                    if (newSum == target)
                    {
                        count++;
                    }
                }

                sums.UnionWith(newSums);
            }

            return count;

        }


          

    }
}
