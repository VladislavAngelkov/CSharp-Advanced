using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            CustomDoublyLinkedList<string> list = new CustomDoublyLinkedList<string>();

            list.AddFirst("pesho");
            list.AddFirst("gosho");
            list.AddFirst("misho");
            list.AddLast("penka");
            list.AddLast("ginka");
            list.AddLast("minka");

            list.ForEach(person => Console.Write($"{person}, "));
            Console.WriteLine();
            Console.WriteLine("----------------------");

            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveFirst());

            Console.WriteLine(list.Count);
        }
    }
}
