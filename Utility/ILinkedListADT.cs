using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListConsoleApp.Utility
{
    internal interface ILinkedListADT<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        void InsertAt(int index, T item);
        T RemoveAt(int index);
        T RemoveFirst(int index);
        T RemoveLast(int index);
        int Index(T item);
        T Get(int index);
        void Clear();
        int Count { get; }
        bool Contains(T item);
    }
}
