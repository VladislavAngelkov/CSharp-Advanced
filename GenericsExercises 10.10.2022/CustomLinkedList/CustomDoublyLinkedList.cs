using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count = 0;
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        public Node<T> Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public int Count
        {
            get { return count; }
        }

        public void AddFirst(T element)
        {
            if (this.Head == null)
            {
                Node<T> head = new Node<T>();
                head.Value = element;
                this.Head = head;
                this.Tail = head;
                count++;
            }
            else
            {
                Node<T> newHead = new Node<T>();
                newHead.Value = element;
                newHead.Next = this.Head;
                this.Head.Previous = newHead;
                this.Head = newHead;
                count++;
            }
            
        }
        public void AddLast(T element)
        {
            if (this.Head == null)
            {
                Node<T> tail = new Node<T>();
                tail.Value = element;
                this.Head = tail;
                this.Tail = tail;
                count++;
            }
            else
            {
                Node<T> newTail = new Node<T>();
                newTail.Value = element;
                newTail.Previous = this.Tail;
                this.Tail.Next = newTail;
                this.Tail = newTail;
                count++;
            }
        }

        public T RemoveFirst()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }
            else if (count == 1)
            {
                T item = this.head.Value;
                head = null;
                tail = null;
                count = 0;
                return item;
            }
            else
            {
                T item = this.head.Value;
                Node<T> newHead = this.Head.Next;
                this.Head = newHead;
                this.Head.Previous = null;
                count--;
                return item;
            }
        }

        public T RemoveLast()
        {
            if (count == 0)
            {
                throw new ArgumentException();
            }
            else if (count == 1)
            {
                T item = this.head.Value;
                head = null;
                tail = null;
                count = 0;
                return item;
            }
            else
            {
                T item = this.tail.Value;
                Node<T> newTail = this.Tail.Previous;
                this.Tail = newTail;
                this.Tail.Next = null;
                count--;
                return item;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> currNode = this.Head;

            while (currNode!=null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public T[] ToArray()
        {
            List<T> list = new List<T>();

            Node<T> currNode = this.Head;

            while (currNode != null)
            {
                list.Add(currNode.Value);
                currNode = currNode.Next;
            }

            T[] result = list.ToArray();
            return result;
        }
    }
}
