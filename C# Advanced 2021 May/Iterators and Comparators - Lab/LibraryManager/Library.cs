using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;

        public Library(params Book[] _books)
        {
            books = new SortedSet<Book>(_books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IList<Book> books;

            private int currentIndex = -1;
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public LibraryIterator(IEnumerable<Book> _books)
            {
                Reset();
                books = new List<Book>(_books);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
