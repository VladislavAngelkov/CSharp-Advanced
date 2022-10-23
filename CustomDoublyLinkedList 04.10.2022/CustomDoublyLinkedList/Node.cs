using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class Node<Т>
    {
        private Node<Т> previous;
        private Node<Т> next;
        private Т value;
        public Node<Т> Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public Node<Т> Next
        {
            get { return next; }
            set { next = value; }
        }
        public Т Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
