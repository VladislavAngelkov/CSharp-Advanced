using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        private Node<T> previous;
        private Node<T> next;
        private T value;
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
