\using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.DataModels
{
    internal class Book
    {
        public class Book : IEquatable<Book>
        {
            static int counter = 0;
            public Book()
            {
                counter++;
                this.Id = counter;

            }
            public int Id { get; private set; }
            public int AuthorId { get; set; }
            public string BookName { get; set; }
            public string AuthorName { get; set; }
            public BookGenre Genre { get; set; }

            public double Price;

            public int Page;

            public bool Equals(Book? other)
            {
                if (other == null) return false;
                return other.Id == this.Id; ;
            }

            public override string ToString()
            {
                return $"Book ID: {Id} Book name: {BookName} Price: {Price} Page: {Page} Genre: {Genre} AuthorID: {AuthorId}";
            }

            public override bool Equals(object? obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}
