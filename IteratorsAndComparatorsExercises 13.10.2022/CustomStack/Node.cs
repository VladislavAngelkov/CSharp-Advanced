using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class Node<T>
    {
        public Node()
        {

        }
        public Node(T value)
        {
            this.value = value;
        }

        private Node<T> next;
        private T value;

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
