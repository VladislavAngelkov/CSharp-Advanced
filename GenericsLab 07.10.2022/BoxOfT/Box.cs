using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            elements = new List<T>();
        }
        private List<T> elements;

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
        public int Count
        {
            get { return elements.Count; }
        }

    }
}
