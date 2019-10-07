using LibaryTask.Menu;
using LibraryTask;
using LibraryTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibaryTask
{
    public class ComandList
    {
        public Library library { get; set; }
        public List<MenuItem> MenuList = new List<MenuItem> ();
        private bool alive;
        public ComandList(Library library)
        {
            this.library = library;
            this.alive = true;

            this.MenuList.Add(new MenuItem { Description = "1 - Вывести список всех названий книг", Execute = ShowAllBookNames });
            this.MenuList.Add(new MenuItem { Description = "2 - Вывести все книги, изданные между 2017 и 2019 годом", Execute = ShowBooksByCondition });
            this.MenuList.Add(new MenuItem { Description = "3 - Вывести книги, которые взяла Дашкова", Execute = ShowBooksById });
            this.MenuList.Add(new MenuItem { Description = "4 - Получить пьяный список ФИО читателе", Execute = DrunkStyle });
        }
        public void MenuStart()
        {
            while (this.alive)
            {
                foreach (MenuItem item in MenuList)
                {
                    Console.WriteLine(item.Description);
                }

                Console.WriteLine("other key - Выход");

                int command = Convert.ToInt32(Console.ReadLine());
                if (command < 0 || command > MenuList.Count)
                {
                    this.alive = false;
                    continue;
                }

                MenuList[command - 1].Execute(library);
            }
        }

        private static void ShowAllBook(IEnumerable<Book> filteredList)
        {
            foreach (Book book in filteredList)
            {
                Console.WriteLine($"Автор: {book.BookAuthor}");
                Console.WriteLine($"Название: {book.BookName}");
                Console.WriteLine($"Год выпуска: {book.BookYear} \n");
            }
        }
        static void ShowAllBookNames(Library library)
        {

            library.Books.ForEach(book => Console.WriteLine(book.BookName));

            foreach (Book book in library.Books)
            {
                library.Books.ForEach(x => { Console.WriteLine(x.BookName); });

                Console.WriteLine(book.BookName);
            }

        }

        static void ShowBooksByCondition(Library library)
        {
            IEnumerable<Book> filteredList = library.Books.Where(b => b.BookYear >= 2017 && b.BookYear <= 2019);

            Console.WriteLine("Книги между 2017-2019 года");
            ShowAllBook(filteredList);
        }

        static void ShowBooksById(Library library)
        {
            int id = 2;
            IEnumerable<Book> booksById = library.Readers.Where(r => r.Id == id).Select(r => r.HoldedBooks).FirstOrDefault();
            ShowAllBook(booksById);
        }

        static void DrunkStyle(Library library)
        {
            Console.WriteLine("Пьяные читатели:");
            foreach (Reader reader in library.Readers)
            {
                Console.WriteLine(reader.FirstName.Drunk() + " " + reader.LastName.Drunk());
                Console.WriteLine();
            }
        }
    }
}
