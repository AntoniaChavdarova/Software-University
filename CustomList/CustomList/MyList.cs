using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] data;
        private int capacity;

        public MyList()
            : this(4)
        {

        }
        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }
        public int Count { get; private set; }
        public void Add(T number)
        {
            CheckIfResizeIsNeeded();

            this.data[this.Count] = number;
            this.Count++;
        }

        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            var newCapacity = this.data.Length * 2;
            var newData = new T[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }  // kopiram stariq masiv

            this.data = newData;
        }

        public int RemoveAll(Func<T , bool> filter)
        {
            var removed = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (filter(this.data[i]))
                {
                    this.RemoveAt(i);
                    removed++;
                }
            }

            return removed;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.capacity];
        }

        public void InsertAt(int index , T element)
        {
            this.ValidateIndex(index);
            this.CheckIfResizeIsNeeded();

            for (int i = this.Count - 1; i >= index; i++)
            {
                this.data[i + 1] = this.data[i];
            }
            this.data[index] = element;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var result = this.data[index];

            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;

            return result;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(this.data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex , int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            var firstValue = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstValue;

        }

        public T this[int index] //Indeksator
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                 this.data[index] = value;
            }
        }

        
        public void ValidateIndex(int index)
        {
            if(index >= this.Count ||  index < 0)
            {
                var message = this.Count == 0
                    ? "The list is empty"
                    : $"The List has {this.Count} elements and it is zero-based";

                throw new Exception($"Index out of range. {message}.");
            }
        }

        public IEnumerator<T> GetEnumerator()

            => this.data.Take(this.Count).ToList().GetEnumerator();
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
