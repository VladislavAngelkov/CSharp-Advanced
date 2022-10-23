using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> SymbolOccurrences = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (!SymbolOccurrences.ContainsKey(currentChar))
                {
                    SymbolOccurrences.Add(currentChar, 0);
                }

                SymbolOccurrences[currentChar]++;
            }

            foreach (var symbol in SymbolOccurrences.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
