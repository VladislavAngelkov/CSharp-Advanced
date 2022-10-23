using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersInfo);

            Queue<int> unservedOreders = new Queue<int>();

            int biggestOrder = orders.Max();

            Console.WriteLine(biggestOrder);

            for (int i = 0; i < ordersInfo.Length; i++)
            {
                int currentOrder = orders.Peek();

                if (currentOrder<=foodQuantity)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
