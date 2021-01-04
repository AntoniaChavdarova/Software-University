using System;
using System.Linq;

namespace InterpolatrionSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());


            Console.WriteLine(InterpolationSearch(nums, num));
        }

        private static int InterpolationSearch(int[] nums, int searched)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (nums[low] <= searched && nums[high] >= searched)
            {

                int mid = low + ((searched - nums[low]) * (high - low))

                / (nums[high] - nums[low]);

                if (nums[mid] < searched)

                    low = mid + 1;

                else if (nums[mid] > searched)

                    high = mid - 1;

                else

                    return mid;

            }

            if (nums[low] == searched) return low;

            else return -1;
        }
    }

 }

