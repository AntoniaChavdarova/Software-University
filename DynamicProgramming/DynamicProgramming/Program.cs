using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        private static Dictionary<int, long> memo;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
             memo = new Dictionary<int, long>();

            Console.WriteLine(GetFibonacci(num) ); 
        }

        private static long GetFibonacci(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n]; 
            }

            if(n <= 2)
            {
                return 1;
            }

            var result = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            memo[n] = result;

            return result;
        }
    }
}
