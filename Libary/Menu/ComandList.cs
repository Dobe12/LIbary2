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
        public Dictionary<int, MenuItem> MenuList = new Dictionary<int, MenuItem>();
        private bool alive;
        public ComandList(Library library)
        {
            this.library = library;
            this.alive = true;

            this.MenuList.Add(1, new MenuItem { Description = "1 - Вывести список всех названий книг", Execute = ShowAllBookNames });
            this.MenuList.Add(2, new MenuItem { Description = "2 - Вывести все книги, изданные между заданными годами", Execute = ShowBooksByCondition });
            this.MenuList.Add(3, new MenuItem { Description = "3 - Вывести книги, определенного пользователя", Execute = ShowBooksById });
            this.MenuList.Add(4, new MenuItem { Description = "4 - Получить пьяный список ФИО читателей", Execute = DrunkStyle });
            this.MenuList.Add(0, new MenuItem { Description = "0 - Выход", Execute = Exit });
        }
        public void MenuStart()
        {
            while (this.alive)
            {
                foreach (var item in MenuList)
                {
                    Console.WriteLine(item.Value.Description);
                }

                int command = Convert.ToInt32(Console.ReadLine());
                System.Console.Clear();

                if (!MenuList.ContainsKey(command)) { continue; }
                MenuList[command].Execute();
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
        private void ShowAllBookNames()
        {
            this.library.Books.ForEach(book => Console.WriteLine(book.BookName));
        }

        private void ShowBooksByCondition()
        {
            Console.WriteLine("С какого года вывести книги ?:");
            int rightYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("По какой год выводить книги ?");
            int leftYear = Convert.ToInt32(Console.ReadLine());

            IEnumerable<Book> filteredList = library.Books.Where(b => b.BookYear >= rightYear && b.BookYear <= leftYear);

            if (filteredList.Count() == 0 || filteredList == null)
            {
                Console.WriteLine("Книги не найдены");
            }
            else
            {
                Console.WriteLine($"Книги изданные между {rightYear}-{leftYear} годами");
                ShowAllBook(filteredList);
            }
        }

        private void ShowBooksById()
        {
            Console.WriteLine("Введите имя пользователя, чьи книги вывести на экран:");
            Console.WriteLine("Подсказка (список доступных пользователей):");

            library.Readers.Select(u => u.LastName).ToList().ForEach(u => Console.WriteLine(u));

            Console.WriteLine();
            string name = Console.ReadLine();
            System.Console.Clear();


            int id = library.Readers.Where(r => r.LastName == name).Select(u => u.Id).FirstOrDefault();
            IEnumerable<Book> booksById = library.Readers.Where(r => r.Id == id).Select(r => r.HoldedBooks).FirstOrDefault();

            if (booksById == null)
            {
                throw new Exception("Пользователь не найден");
            }
            else
            {
                Console.WriteLine($"Книги пользователя ({name}):");
            }

            ShowAllBook(booksById);
        }

        private void DrunkStyle()
        {
            Console.WriteLine("Пьяные читатели:");
            foreach (Reader reader in library.Readers)
            {
                Console.WriteLine(reader.FirstName.Drunk() + " " + reader.LastName.Drunk());
            }
        }

        private void Exit()
        {
            alive = false;
        }
    }
}
