using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
   public class LinkedList
    {

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node newHead)
        {
           if(Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddTail(Node newTail)
        {
            if(Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public Node RemoveFirst()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;
            Head.Previous = null;
            return oldHead;
        }

        public Node RemoveLast()
        {
            var oldTail = this.Tail;
            this.Tail = this.Tail.Previous;
            Tail.Next = null;

            return oldTail;
        }

        public void ForEach(Action<Node> action)
        {
            Node currNode = Head;
            while (currNode != null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }
        public void PrintList()
        {
            this.ForEach(node => Console.WriteLine(node.Value));
            
        }

        public int [] ToArray()
        {
            List<int> list = new List<int>();
            this.ForEach(node => list.Add(node.Value));
            return list.ToArray();
        }

       
    }
}
