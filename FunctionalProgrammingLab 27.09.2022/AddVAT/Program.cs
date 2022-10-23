using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> VATAdder = (n) =>
            {
                double num = double.Parse(n);
                num *= 1.2;
                return num.ToString("F2");
            };

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(VATAdder).ToArray()));
        }
    }
}
