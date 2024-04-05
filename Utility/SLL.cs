using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedListConsoleApp.Utility
{
    internal class SLL<T> : ILinkedListADT<T> where T : IComparable<T>

    {
        private Node<T> head;
        private int count;

        public SLL() 
        {
            head = null;
            count = 0;

        }
        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item) { Next = head };
            head = newNode;
            count++;
        }
        public void AddLast(T item)
        {
            if ( head == null)
            {
                AddFirst(item);
                return;
            }
            Node<T> current = head;
            while (current.Next != null) { 
            current = current.Next;}
            current.Next = new Node<T>(item);
            count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count) throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddFirst(item);
                return;
            }

            Node<T> current = head;
            Node<T> previous = null;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            Node<T> newNode = new Node<T>(item) { Next = current };
            previous.Next = newNode;
            count++;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = head;
            Node<T> previous = null;

            if (index == 0)
            {
                head = head.Next;
                count--;
                return current.Data;
            }

            int currentIndex = 0;
            while (currentIndex < index)
            {
                previous = current;
                current = current.Next;
                currentIndex++;
            }

            previous.Next = current.Next;
            count--;
            return current.Data;
        }

        public T RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty");

            return RemoveAt(0);
        }

        public T RemoveLast()
        {
            if (head == null) throw new InvalidOperationException("List is empty");

            return RemoveAt(count - 1);
        }

        public int Index(T item)
        {
            int index = 0;
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(item)) return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");

            Node<T> current = head;
            int currentIndex = 0;

            while (currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            return current.Data;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public int Count()
        {
            return count;
        }

        public bool Contains(T item)
        {
            return Index(item) != -1;
        }

        public void Reverse()
        {
            Node<T> previous = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public void Sort()
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            do
            {
                Node<T> current = head;
                Node<T> previous = null;
                swapped = false;

                while (current.Next != null)
                {
                    if (current.Data.CompareTo(current.Next.Data) > 0)
                    {
                        Node<T> temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;

                        if (previous == null)
                            head = temp;
                        else
                            previous.Next = temp;

                        swapped = true;
                    }

                    previous = current;
                    if (current.Next != null)
                        current = current.Next;
                }
            } while (swapped);
        }
    }
}
