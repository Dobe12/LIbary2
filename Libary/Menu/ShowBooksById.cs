using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryTask.Models;

namespace LibaryTask.Menu
{
    class ShowBooksById : AllBooks, IMenu
    {
        private string Description = " 3 -  Вывести книги, которые взяла Дашкова ";
        public void Start(Library library)
        {
            int id = 2;
            IEnumerable<Book> booksById = library.Readers.Where(r => r.Id == id).Select(r => r.HoldedBooks).FirstOrDefault();
            Show(booksById);
        }
    }
}
