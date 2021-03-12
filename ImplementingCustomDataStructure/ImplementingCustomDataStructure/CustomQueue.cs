using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomDataStructure
{
    public class CustomQueue
    {
        private const int INITIAL_CAPACITY = 4;
        private const string EMPTY_QUEUE_MSG = "Queue is empty";

        private int[] items;
        private int front;
        private int rear;

        public CustomQueue()
        {
            this.items = new int[INITIAL_CAPACITY];
            this.rear = 0;
            this.front = 0;
        }

        public int Count => this.rear;


        public void Enqueue(int item)
        {
           
            if (this.Count == this.items.Length)
            {
                Resize();
            }

           items[rear] = item;
            rear++;
           // Count++;
           
        }

        public int Dequeue()
        {
            Validation();

            for (int i = 0; i < rear; i++)
            {
                items[i] = items[i + 1];
            }

            rear--;
            //Count--;

            return items[front];
        }

        public void ForEach()
        {
           
            // traverse front to rear and print elements  
            for (int i = front; i < rear; i++)
            {
                Console.Write(items[i] + " ");
            }
          
        }

        private void Validation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_QUEUE_MSG);
            }

        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = this.items[i]; 
            }

            this.items = copy;
        }
    }
}
