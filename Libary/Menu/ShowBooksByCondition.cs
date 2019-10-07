using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryTask.Models;

namespace LibaryTask.Menu
{
    public  class ShowBooksByCondition : AllBooks, IMenu
    {
        private string Description = " 2 - Вывести все книги, изданные между 2017 и 2019 годом ";
        public  void Start(Library library)
        {
            IEnumerable<Book> filteredList = library.Books.Where(b => b.BookYear >= 2017 && b.BookYear <= 2019);

            Console.WriteLine("Книги между 2017-2019 года");
            Show(filteredList);
        }
    }
}
