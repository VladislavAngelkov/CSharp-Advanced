using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> elements;

        private int currentPosition;

        public ListyIterator(params T[] elements)
        {
            this.elements = elements.ToList();
            currentPosition = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentPosition++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            return currentPosition+1 < elements.Count;
        }

        public void Print()
        {
            if (elements.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }
            Console.WriteLine(elements[currentPosition]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintAll()
        {
            foreach (var item in elements)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
