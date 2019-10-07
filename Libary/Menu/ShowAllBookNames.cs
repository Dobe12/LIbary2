using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Models;

namespace LibaryTask.Menu
{
    public class ShowAllBookNames : AllBooks, IMenu
    {
        private string Description = " 1 - Вывести список всех названий книг ";
        public void Start(Library library)
        {
            library.Books.ForEach(book => Console.WriteLine(book.BookName));

            foreach (Book book in library.Books)
            {
                library.Books.ForEach(x => { Console.WriteLine(x.BookName); });

                Console.WriteLine(book.BookName);
            }
        }
    }
}
