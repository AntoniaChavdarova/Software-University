using System;

namespace ImplementingCustomDataStructure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }

            stack.ForEach(e =>
            {
                Console.WriteLine(e);
            }
            );

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(stack.Peek());
                Console.WriteLine(stack.Pop());
            }

            stack.Pop();
        }
    }
}
