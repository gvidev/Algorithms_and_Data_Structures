using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinearStructures
{
    //A linked list is called a dynamic data structure because
    //it can be used with a data collection
    //that grows and shrinks during program execution.
    public class LinkedList<T>
    {
        private class ListNode
        {
            public T Item { get; set; }
            public ListNode NextNode { get; set; }

            public ListNode(T item, ListNode prevNode)
            {
                this.Item = item;
                prevNode.NextNode = this;
            }

            public ListNode(T item)
            {
                this.Item = item;
                this.NextNode = null;
            }
        }

        private ListNode head;
        private ListNode tail;
        private int count;

        //gets the count of elements in the list
        public int Count => this.count;

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T item)
        {
            if (head == null)
            {
                this.head = new ListNode(item);
                this.tail = this.head;
            }
            else
            {
                ListNode newNode = new ListNode(item, tail);
                this.tail = newNode;
            }
            count++;
        }

        public T RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new IndexOutOfRangeException($"Invalid index: {index}");
            }

            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            RemoveListNode(currentNode, prevNode);


            return currentNode.Item;
        }


        private void RemoveListNode(ListNode node, ListNode prevNode)
        {

            this.count--;

            if (this.count == 0)
            {
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                this.head = node.NextNode;
            }
            else
            {
                prevNode.NextNode = node.NextNode;
            }

            if (object.Equals(this.tail, node))
            {
                this.tail = prevNode;
            }
        }

        public int Remove(T item)
        {
            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Item, item))
                {
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            if (currentNode != null)
            {
                this.RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }
            else {
                return -1;
            }

        }

        public int IndexOf(T item)
        {
            int index = 0;
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Item, item))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;

        }


        public bool Contains(T item)
        {
            int index = IndexOf(item);
            bool check = (index != -1);

            return check;
        }

        public T this[int index]
        {
            get
            {
                if(index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                ListNode currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                return currentNode.Item;
            }

            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new IndexOutOfRangeException($"Invalid index: {index}");
                }

                ListNode currentNode = this.head;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.Item = value;

            }
        }


        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($" -  {this[i]}" );
            }
        }


        


    }
}
