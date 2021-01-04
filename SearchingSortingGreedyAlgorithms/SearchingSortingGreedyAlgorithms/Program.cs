using System;
using System.Linq;

namespace SearchingSortingGreedyAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(nums, num));

          
        }

     

        private static int BinarySearch(int[] nums, int searchedNum)
        {
            var startIdx = 0; //left
            var endIdx = nums.Length - 1; //right

            while (startIdx <= endIdx)
            {
                var mid = (startIdx + endIdx) / 2;
                if (nums[mid] == searchedNum)
                {
                    return mid;
                }

                if (searchedNum > nums[mid])
                {
                    startIdx = mid + 1;
                }
                else
                {
                    endIdx = mid - 1;
                }

            }

            return -1;
        }
    }
}
