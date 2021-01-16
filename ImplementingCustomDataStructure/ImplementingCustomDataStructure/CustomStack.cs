using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingCustomDataStructure
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;
        private const string EMPTY_STACK_MSG = "Stack is empty";

        private int[] items;

        public CustomStack()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if(this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int Pop()
        {
            Validation();

            int poppedItem = this.items[this.Count - 1];
            this.items[this.Count - 1] = default;
            this.Count--;

            return poppedItem;
        }

        public int Peek()
        {
            Validation();

            int lastItem = this.items[this.Count - 1];

            return lastItem;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        private void Validation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EMPTY_STACK_MSG);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

       

    }
}
