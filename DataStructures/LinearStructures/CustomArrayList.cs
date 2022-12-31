using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearStructures
{
    public class CustomArrayList<T>
    {
        private static readonly int INITIAL_CAPACITY = 4;

        private T[] array;
        private int count;

        //returns the count
        public int Count => this.count;

        public CustomArrayList()
        {
            array = new T[INITIAL_CAPACITY];
            count = 0;
        }

        //method that keep track on that when array should be extended
        public void GrowIfArrIsFull()
        {
            if (this.count + 1 > this.array.Length)
            {
                T[] extendedArray = new T[this.array.Length * 2];
                Array.Copy(this.array, extendedArray, this.count);
                this.array = extendedArray;
            }
        }

        public void Add(T item)
        {
            this.GrowIfArrIsFull();
            this.array[this.count] = item;
            count++;
        }

        public void Insert(int index, T item)
        {
            if (index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}");
            }

            this.GrowIfArrIsFull();
            //coping the elements from that index to the end of the array and pasting 
            //them with one position to the right
            //this makes the position arr[index] -> empty
            Array.Copy(this.array, index, this.array, index + 1, this.count - index);
            this.array[index] = item;
            this.count++;
        }

        public void Clear()
        {
            this.array = new T[INITIAL_CAPACITY];
            this.count = 0;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.array.Length; i++)
            {
                //here i am using object.Equals because method allows null references
                //I can simply use this.array[i].Equals(item) but it can failed because of null references
                if (object.Equals(item, this.array[i]))
                {
                    return i;
                }
            }
            //when we dont find the element in the array 
            return -1;
        }

        public bool Contains(T item)
        {
            //first way is using already writen methods but that`s not honest
            //return this.array.Contains(item);

            //second way - the honest one
            //using the method IndexOf that I already wrote
            int index = IndexOf(item);
            bool check = (index != -1);
            return check;
        }

        //access to element at given index
        public T this[int index]
        {
            get
            {
                if (index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }
                return this.array[index];
            }
            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }
                this.array[index] = value;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}");
            }

            //saving the item that will be deleted
            T item = this.array[index];
            //coping the elements after the element at position [index+1]
            //and pasting from the position [index] in the destinationArray
            Array.Copy(this.array, index + 1, this.array, index, this.count - index - 1);
            //setting the last element by default of the type T
            this.array[count - 1] = default;
            this.count--;
            return item;

        }

        public int Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                this.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Item not found!");
            }

            return index;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(this.array[i] + " ");
            }
            Console.WriteLine();
        }




    }
}
