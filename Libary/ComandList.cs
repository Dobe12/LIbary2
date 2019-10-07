using LibraryTask;
using LibraryTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibaryTask
{
    class ComandList
    {
        public Library library { get; set; }
        public List<Tuple<string, Action<Library> > > TuplesList = new List<Tuple<string, Action<Library>>>();
        private bool alive;

        public ComandList(Library library)
        {
            this.library = library;
            this.alive = true;
            Action<Library> test = ShowAllBookNames;

            this.TuplesList.Add(new Tuple<string, Action<Library>>("0 - Вывести список всех названий книг", ShowAllBookNames));
            this.TuplesList.Add(new Tuple<string, Action<Library>>("1 - Вывести все книги, изданные между 2017 и 2019 годом", ShowBooksByCondition));
            this.TuplesList.Add(new Tuple<string, Action<Library>>("2 - Вывести книги, которые взяла Дашкова", ShowBooksById));
            this.TuplesList.Add(new Tuple<string, Action<Library>>("3 - Получить пьяный список ФИО читателе", DrunkStyle));
        }
        public  void MenuStart()
        {

            while(this.alive)
            {
                foreach(Tuple<string, Action<Library>> tuple in TuplesList)
                {
                    Console.WriteLine(tuple.Item1);
                }

                Console.WriteLine("4 - Выход");

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {

                        case 0:
                            TuplesList[0].Item2(library);
                            break;
                        case 1:
                            TuplesList[1].Item2(library);
                            break;
                        case 2:
                            TuplesList[2].Item2(library);
                            break;
                        case 3:
                            TuplesList[3].Item2(library);
                            break;
                        case 4:
                            this.alive = false;
                            continue;
                    }

                }
                catch (Exception ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = Console.ForegroundColor;
                }
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
        static void  ShowAllBookNames(Library library)
        {
            foreach (Book book in library.Books)
            {
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
