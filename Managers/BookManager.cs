using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Managers
{
    internal class BookManager
    {
        public class BookManager : IManager<Book>, IEnumerable<Book>
        {
            Book[] books = new Book[0];
            public void Add(Book item)
            {
                int len = books.Length;
                Array.Resize(ref books, len + 1);
                books[len] = item;
            }

            public void Edit(Book item)
            {
                int index = Array.IndexOf(books, item);
                if (index == -1)
                    return;
                var found = books[index];
                found.BookName = item.BookName;
                found.AuthorId = item.AuthorId;
                found.Genre = item.Genre;
                found.Page = item.Page;
                found.Price = item.Price;
            }

            public void Read(Book item)
            {
                throw new NotImplementedException();
            }

            public void Remove(Book item)
            {
                int index = Array.IndexOf(books, item);
                if (index == -1)
                    return;
                int len = books.Length - 1;
                for (int i = index; i < len; i++)
                {
                    books[i] = books[i + 1];
                }
                Array.Resize(ref books, len);
            }

            public Book this[int index]
            {
                get
                {
                    return books[index];
                }
            }
            public IEnumerator<Book> GetEnumerator()
            {
                foreach (var item in books)
                {
                    yield return item;
                };
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public Book GetById(int id)
            {
                return Array.Find(books, item => item.Id == id);
            }
            public Book[] FindByName(string name)
            {
                return Array.FindAll(books, item => item.BookName.ToLower().StartsWith(name.ToLower()));
            }
        }
    }
}
