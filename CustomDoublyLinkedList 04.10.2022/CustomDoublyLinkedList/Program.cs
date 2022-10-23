using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(int.Parse(Console.ReadLine()));
            list.AddFirst(int.Parse(Console.ReadLine()));
            list.AddFirst(int.Parse(Console.ReadLine()));
            list.AddLast(int.Parse(Console.ReadLine()));
            list.AddLast(int.Parse(Console.ReadLine()));
            list.AddLast(int.Parse(Console.ReadLine()));

            Console.WriteLine("------------------------------");

            Node<int> currNode = list.Head;
            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                currNode = currNode.Next;
            }

            Console.WriteLine("------------------------------");

            Action<int> add = num => num++;
            Action<int> print = num => Console.WriteLine(num);

            list.ForEach(n=>add(n));
            list.ForEach(n => print(n));

            list.RemoveFirst();
            list.RemoveLast();

            int[] array = list.ToArray();

            Console.WriteLine("------------------------------");

            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine(list.Count);
        }
    }
}
