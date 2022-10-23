using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private Book[] books;

        public Library(params Book[] books)
        {
            this.books = books;
        }

        public Book[] Books
        {
            get { return books; }
            private set { books = value; }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(Book[] books)
        {
            this.books = books;
            Reset();
        }

        private Book[] books;
        private int currentIndex;

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < this.books.Length;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
    }

    
}
