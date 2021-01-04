using System;
using System.Linq;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {

            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SelectionSort(nums);

            Console.WriteLine(String.Join(" " , nums));
        }

        private static void SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
               var minIdx = i;
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if(nums[j] < nums[minIdx])
                    {
                        minIdx = j;
                    }
                }

                Swap(nums, i, minIdx);

            }
        }

        private static void Swap(int[] nums, int i, int minIdx)
        {
            var temp = nums[i];
            nums[i] = nums[minIdx];
            nums[minIdx] = temp;
        }
    }
}
