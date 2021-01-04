using System;
using System.Linq;

namespace BubblesAndInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(nums);
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            InsertionSort(numbers);
            Console.WriteLine(String.Join(" ", nums));
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void InsertionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var j = i;
                while (j > 0 && nums[j] < nums[j - 1])
                {
                    Swap(nums, j, j - 1);
                    j--;
                }

            }
        }

        private static void BubbleSort(int[] nums)
        {
            var isSorted = false;
            var i = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[j - 1] > nums[j])
                    {
                        isSorted = false;
                        Swap(nums, j - 1, j);
                    }
                }

                i += 1;

            }
        }

        private static void Swap(int[] nums, int first, int sec)
        {
            var temp = nums[first];
            nums[first] = nums[sec];
            nums[sec] = temp;
        }
    }
}
