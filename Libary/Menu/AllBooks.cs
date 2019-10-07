using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask.Models;

namespace LibaryTask.Menu
{
    public abstract class AllBooks
    {
        public static void Show(IEnumerable<Book> filteredList)
        {
            foreach (Book book in filteredList)
            {
                Console.WriteLine($"Автор: {book.BookAuthor}");
                Console.WriteLine($"Название: {book.BookName}");
                Console.WriteLine($"Год выпуска: {book.BookYear} \n");
            }
        }
    }
}
