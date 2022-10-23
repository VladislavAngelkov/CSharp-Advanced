using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> printUpper = (w) =>
            {
                return char.IsUpper(w[0]);
                
            };
            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(printUpper).ToArray()));


            //new char[] { ' ', '.', ',', '!', '?', ':', ';', '-' }
        }
    }
}
