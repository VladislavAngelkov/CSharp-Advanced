using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public CustomStack(params T[] elements)
        {
            count = 0;
            this.Push(elements);
        }

        private Node<T> head;
        private int count;
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public int Count
        {
            get { return count; }
        }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head = newNode;
            }
            count++;
        }

        public void Push(params T[] elements)
        {
            foreach (var item in elements)
            {
                this.Push(item);
            }
        }

        public T Pop()
        {
            if (count == 0)
            {
                Console.WriteLine("No elements");
                return default;
            }
            count--;
            T result = head.Value;
            head = head.Next;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = new Node<T>();
            currentNode.Next = this.head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
