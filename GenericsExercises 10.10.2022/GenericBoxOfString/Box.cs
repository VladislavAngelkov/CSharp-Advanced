using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T> where T:IComparable<T>
    {
        public Box()
        {
            elements = new List<T>();
        }
        
        private List<T> elements;

        public int Count
        {
            get { return elements.Count; }
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T element = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return element;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString();
        }

        public void Swap(int indexOne, int indexTwo)
        {
            T temp = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = temp;
        }

        public int Compare(T value)
        {
            int result = 0;
            foreach (var item in elements)
            {
                if (item.CompareTo(value) > 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
