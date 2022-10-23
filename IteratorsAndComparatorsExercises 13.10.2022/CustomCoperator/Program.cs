using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomCoperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(array, new CustomCopmerator());

            Console.WriteLine(string.Join(" ", array));
        }

        public class CustomCopmerator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int result = 0;
                if (x % 2 == 0 && y % 2 == 0)
                {
                    result = x - y;
                }
                else if (x % 2 != 0 && y % 2 != 0)
                {
                    result = x - y;
                }
                else if (x % 2 == 0 && y % 2 != 0)
                {
                    result = -1;
                }
                else
                {
                    result = 1;
                }

                return result;
            }
        }
    }
    
}
