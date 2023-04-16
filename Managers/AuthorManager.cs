using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Managers
{
    internal class AuthorManager
    {
        public class AuthorManager : IManager<Author>, IEnumerable<Author>
        {
            Author[] authors = new Author[0];
            public void Add(Author item)
            {
                int len = authors.Length;
                Array.Resize(ref authors, len + 1);
                authors[len] = item;
            }

            public void Edit(Author item)
            {
                int index = Array.IndexOf(authors, item);
                if (index == -1)
                    return;
                var found = authors[index];
                found.Name = item.Name;
                found.Surname = item.Surname;
            }

            public void Remove(Author item)
            {
                int index = Array.IndexOf(authors, item);
                if (index == -1)
                    return;
                int len = authors.Length - 1;
                for (int i = index; i < len; i++)
                {
                    authors[i] = authors[i + 1];
                }
                Array.Resize(ref authors, len);
            }

            public void Read(Author item)
            {
                throw new NotImplementedException();
            }

            public Author this[int index]
            {
                get
                {
                    return authors[index];
                }
            }
            public IEnumerator<Author> GetEnumerator()
            {
                foreach (var item in authors)
                {
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public Author GetById(int id)
            {
                return Array.Find(authors, item => item.Id == id);
            }

            public Author[] FindByName(string name)
            {
                return Array.FindAll(authors, item => item.Name.ToLower().StartsWith(name.ToLower()));
            }
        }
    }
}
