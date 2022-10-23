using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private string title;
        private int year;
        private List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.title = title;
            this.year = year;
            this.authors = authors.ToList();
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public List<string> Authors
        {
            get { return authors; }
            private set { authors = value; }
        }

        public int CompareTo(Book other)
        {
            int result = this.year.CompareTo(other.year);
            if (result == 0)
            {
                result = this.title.CompareTo(other.title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.title} - {this.year}";
        }
    }
}
