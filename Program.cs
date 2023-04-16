using LibraryProject.DataModels;
using LibraryProject.Enums;
using LibraryProject.Managers;

namespace LibraryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {

                AuthorManager authorManager = new AuthorManager();
                BookManager bookManager = new BookManager();

                MenuTypes operations;
                Author author;
                Book book;
                int id;
                ConsoleColor oldColor = Console.ForegroundColor;
            l1:
                Console.WriteLine("Emeliyyati siyahidan sechin: ");
                operations = Helper.ReadEnum<MenuTypes>("Emeliyyatlar menusu: ");
                switch (operations)
                {
                    case MenuTypes.AuthorAdd:
                        author = new Author();
                        author.Name = Helper.ReadString("Muellifin adi: ");
                        author.Surname = Helper.ReadString("Muellifin soyadi: ");
                        authorManager.Add(author);
                        Console.Clear();
                        goto l1;

                    case MenuTypes.AuthorEdit:
                        Console.WriteLine("Redakt etmek istediyiniz muellifi sechin: ");
                        foreach (var item in authorManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Muellifin IDsi: ");
                        if (id == 0)
                        {
                            goto l1;
                        }
                        author = authorManager.GetById(id);
                        if (author == null)
                        {
                            Console.Clear();
                            goto case MenuTypes.AuthorEdit;
                        }
                        author.Name = Helper.ReadString("Muellifin adi: ");
                        author.Surname = Helper.ReadString("Muellifin soyadi: ");
                        Console.Clear();
                        goto case MenuTypes.AuthorGetAll;

                    case MenuTypes.AuthorRemove:
                        Console.WriteLine("Silmek istediyiniz muellifi sechin: ");
                        foreach (var item in authorManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Muellifin IDsi: ");
                        author = authorManager.GetById(id);
                        if (author == null)
                        {
                            Console.Clear();
                            goto case MenuTypes.AuthorRemove;
                        }
                        authorManager.Remove(author);
                        Console.Clear();
                        goto case MenuTypes.AuthorGetAll;

                    case MenuTypes.AuthorGetAll:
                        Console.Clear();
                        foreach (var item in authorManager)
                        {
                            Console.WriteLine(item);
                        }
                        goto l1;

                    case MenuTypes.AuthorGetById:
                        id = Helper.ReadInt("Muellifin IDsi: ");
                        if (id == 0)
                        {
                            Console.Clear();
                            goto l1;
                        }
                        author = authorManager.GetById(id);
                        if (author == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tapilmadi");
                            Console.ForegroundColor = oldColor;
                            goto case MenuTypes.AuthorGetById;
                        }
                        Console.WriteLine(author);
                        goto l1;

                    case MenuTypes.AuthorFindByName:
                        string nameAuthor = Helper.ReadString("Axtarish uchun adin en azi 3 herfin qeyd edin: ");
                        var dataAuthor = authorManager.FindByName(nameAuthor);

                        if (dataAuthor.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tapilmadi");
                            Console.ForegroundColor = oldColor;
                            goto case MenuTypes.AuthorFindByName;
                        }
                        foreach (var item in dataAuthor)
                        {
                            Console.WriteLine(item);
                        }
                        goto l1;

                    case MenuTypes.BookAdd:

                        book = new Book();
                        book.BookName = Helper.ReadString("Kitabin adi: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    l2: Console.WriteLine("Kitabin hansi muellife aid oldugunu sechin: ");
                        Console.ForegroundColor = oldColor;
                        foreach (var item in authorManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Muellifin IDsi: ");
                        if (id == 0)
                        {
                            goto l1;
                        }
                        author = authorManager.GetById(id);
                        if (author == null)
                        {
                            Console.Clear();
                            goto l2;
                        }
                        book.AuthorId = author.Id;
                        Console.ForegroundColor = ConsoleColor.Green;
                    l3: Console.WriteLine("Seyfelerin sayin daxil edin: ");
                        Console.ForegroundColor = oldColor;
                        int pageCount;
                        if (int.TryParse(Console.ReadLine(), out pageCount) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seyfelerin sayi tam eded olmalidi");
                            Console.ForegroundColor = oldColor;
                            goto l3;
                        }
                        if (pageCount < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seyfelerin sayi menfi eded ola bilmez");
                            Console.ForegroundColor = oldColor;
                            goto l3;
                        }
                        book.Page = pageCount;
                        Console.ForegroundColor = ConsoleColor.Green;
                    l4: Console.WriteLine("Qiymeti daxil edin: ");
                        Console.ForegroundColor = oldColor;
                        double BookPrice;
                        if (double.TryParse(Console.ReadLine(), out BookPrice) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Qiymet eded olmalidir");
                            Console.ForegroundColor = oldColor;
                            goto l4;
                        }
                        if (BookPrice < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Qiymet menfi eded ola bilmez");
                            Console.ForegroundColor = oldColor;
                            goto l4;
                        }
                        book.Price = BookPrice;
                        var selectGenre = Helper.ReadEnum<BookGenre>("Kitabin janri: ");
                        book.Genre = selectGenre;
                        bookManager.Add(book);
                        Console.Clear();
                        goto l1;

                    case MenuTypes.BookEdit:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Redakt etmek istediyiniz kitabi sechin: ");
                        Console.ForegroundColor = oldColor;
                        foreach (var item in bookManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Kitabin IDsi: ");
                        if (id == 0)
                        {
                            goto l1;
                        }
                        book = bookManager.GetById(id);
                        if (book == null)
                        {
                            Console.Clear();
                            goto case MenuTypes.BookEdit;
                        }
                        book.BookName = Helper.ReadString("Kitabin adi: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                    l5: Console.WriteLine("Kitabin hansi muellife aid oldugunu sechin: ");
                        Console.ForegroundColor = oldColor;
                        foreach (var item in authorManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Muellifin IDsi: ");
                        if (id == 0)
                        {
                            goto l5;
                        }
                        author = authorManager.GetById(id);
                        if (author == null)
                        {
                            Console.Clear();
                            goto l5;
                        }
                        book.AuthorId = author.Id;
                        Console.ForegroundColor = ConsoleColor.Green;
                    l6: Console.WriteLine("Seyfelerin sayin daxil edin: ");
                        Console.ForegroundColor = oldColor;
                        if (int.TryParse(Console.ReadLine(), out pageCount) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seyfelerin sayi tam eded olmalidi");
                            Console.ForegroundColor = oldColor;
                            goto l6;
                        }
                        if (pageCount < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Seyfelerin sayi menfi eded ola bilmez");
                            Console.ForegroundColor = oldColor;
                            goto l6;
                        }
                        book.Page = pageCount;
                        Console.ForegroundColor = ConsoleColor.Green;
                    l7: Console.WriteLine("Qiymeti daxil edin: ");
                        Console.ForegroundColor = oldColor;
                        if (double.TryParse(Console.ReadLine(), out BookPrice) == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Qiymet eded olmalidir");
                            Console.ForegroundColor = oldColor;
                            goto l7;
                        }
                        if (BookPrice < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Qiymet menfi eded ola bilmez");
                            Console.ForegroundColor = oldColor;
                            goto l7;
                        }
                        book.Price = BookPrice;

                        var selectGenre1 = Helper.ReadEnum<BookGenre>("Kitabin janri: ");
                        book.Genre = selectGenre1;
                        Console.Clear();
                        goto case MenuTypes.BookGetAll;


                    case MenuTypes.BookRemove:
                        Console.WriteLine("Silmek istediyiniz kitabi sechin: ");
                        foreach (var item in bookManager)
                        {
                            Console.WriteLine(item);
                        }
                        id = Helper.ReadInt("Kitabin IDsi: ");
                        book = bookManager.GetById(id);
                        if (book == null)
                        {
                            Console.Clear();
                            goto case MenuTypes.BookRemove;
                        }
                        bookManager.Remove(book);
                        Console.Clear();
                        goto case MenuTypes.BookGetAll;

                    case MenuTypes.BookGetAll:
                        Console.Clear();
                        foreach (var item in bookManager)
                        {
                            Console.WriteLine(item);
                        }
                        goto l1;
                    case MenuTypes.BookGetById:
                        id = Helper.ReadInt("Kitabin IDsi: ");
                        if (id == 0)
                        {
                            Console.Clear();
                            goto l1;
                        }
                        book = bookManager.GetById(id);
                        if (book == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tapilmadi");
                            Console.ForegroundColor = oldColor;
                            goto case MenuTypes.BookGetById;
                        }
                        Console.WriteLine(book);
                        goto l1;

                    case MenuTypes.BookFindByName:
                        string nameBook = Helper.ReadString("Axtarish uchun kitabin adinin en azi 3 herfin qeyd edin: ");
                        var dataBook = authorManager.FindByName(nameBook);

                        if (dataBook.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Tapilmadi");
                            Console.ForegroundColor = oldColor;
                            goto case MenuTypes.BookFindByName;
                        }
                        foreach (var item in dataBook)
                        {
                            Console.WriteLine(item);
                        }
                        goto l1;

                }
            }
        }
    }
}