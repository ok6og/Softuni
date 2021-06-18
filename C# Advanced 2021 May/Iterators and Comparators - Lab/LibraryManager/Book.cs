using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public IEnumerable<string> Authors { get; private set; }


        public Book(string title, int year, params string[] authors )
        {
            Title = title;
            Year = year;
            Authors = new List<string>(authors);
        }

        public int CompareTo(Book other)
        {
            if (this.Year != other.Year)
            {
                return this.Year - other.Year;
            };

            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
