using System;
using System.Collections.Generic;

namespace ImplementingCustomDataStructure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //CustomStack stack = new CustomStack();

            //for (int i = 1; i <= 5; i++)
            //{
            //    stack.Push(i);
            //}

            //stack.ForEach(e =>
            //{
            //    Console.WriteLine(e);
            //}
            //);

            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine(stack.Peek());
            //    Console.WriteLine(stack.Pop());
            //}

            //stack.Pop();

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            queue.Dequeue();
            

            Console.WriteLine(String.Join(" " , queue));

            var queue1 = new CustomQueue();

            for (int i = 1; i <= 9; i++)
            {
                queue1.Enqueue(i);
            }
            queue1.Dequeue();
            queue1.Dequeue();
            Console.WriteLine(queue1.Count); 

            queue1.ForEach();

        }
    }
}
