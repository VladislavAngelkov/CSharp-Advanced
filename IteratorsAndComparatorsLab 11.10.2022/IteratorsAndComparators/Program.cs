using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002,
                "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Console.WriteLine(bookOne.CompareTo(bookTwo));

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo.OrderBy(b=>b))
            {
                Console.WriteLine(book);
            }
        }
    }
}
