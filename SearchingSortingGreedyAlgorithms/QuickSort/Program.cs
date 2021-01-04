using System;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(nums , 0  , nums.Length-1);
            Console.WriteLine(String.Join(" ", nums));
        }

        private static void QuickSort(int[] nums, int start, int end)
        {
           if(start >= end)
            {
                return;
            }

            var pivot = start;
            var leftIdx = start + 1;
            var rightIdx = end;

            while (leftIdx <= rightIdx)
            {
                if(nums[leftIdx] > nums[pivot] && nums[rightIdx] < nums[pivot])
                {
                    Swap(nums, leftIdx, rightIdx);
                }

                if(nums[leftIdx] <= nums[pivot])
                {
                    leftIdx += 1;
                }

                if(nums[rightIdx] >= nums[pivot])
                {
                    rightIdx -= 1;
                }
            }

            Swap(nums, pivot, rightIdx);
           

            var isLeftSubArraysSmaller =
             rightIdx - 1 - start < end - (rightIdx + 1);

            if (isLeftSubArraysSmaller)
            {
                QuickSort(nums, start, rightIdx - 1);
                QuickSort(nums, rightIdx + 1, end);
            }
            else
            {
                QuickSort(nums, rightIdx + 1, end);
                QuickSort(nums, start, rightIdx - 1);
               
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
