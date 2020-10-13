using System;

namespace ImplementingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            for (int i = 1; i <= 5; i++)
            {
                linkedList.AddHead(new Node(i));
            }

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.PrintList();
           

            for (int i = 1; i <= 10 ; i++)
            {
                linkedList.AddTail(new Node(i));
            }

            var array = linkedList.ToArray();
            Console.WriteLine(String.Join(", ", array));

            
        }
    }
}
