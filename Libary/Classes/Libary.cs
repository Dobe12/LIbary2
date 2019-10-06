using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace LibaryTask.Models
{
    public class Libary
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Reader> Readers { get; set; } = new List<Reader>();


        public  void AddDataToLibary(List<IEnumerable<XElement>> list)
        {
            foreach (IEnumerable<XElement> item in list)
            {
                foreach (XElement element in item)
                {
                    if (element.Name == "book")
                    {
                        this.Books.Add(new Book
                        {
                            BookAuthor = element.Attribute("bookAuthor")?.Value,
                            BookName = element.Attribute("bookName")?.Value,
                            BookYear = Convert.ToInt32(element.Attribute("bookYear")?.Value),
                            Id = Convert.ToInt32(element.Attribute("id").Value)
                        });
                    }
                    else if (element.Name == "reader")
                    {
                        List<Book> holdedBooks = new List<Book>();
                        foreach(XElement bookHoldedElement in element.Elements("holdedBooks"))
                        {
                            Console.WriteLine(bookHoldedElement.Value);
                            int id = Convert.ToInt32(bookHoldedElement.Element("bookHolded").Attribute("id").Value);

                            holdedBooks.Add(Books.Where(b => b.Id == id).FirstOrDefault());
                        }
                        this.Readers.Add(new Reader
                        {
                            FirstName = element.Attribute("FirstName").Value,
                            LastName = element.Attribute("LastName").Value,
                            Id = Convert.ToInt32(element.Attribute("id").Value),
                            DateOfBirth = Convert.ToDateTime(element.Attribute("DateOfBirth").Value),
                            HoldedBooks = holdedBooks

                        });
                    }
                    else
                    {
                        throw new Exception("Ошибочный элемент");
                    }


                }
            }

        }
        public void ShowAllBookNames()
        {
            foreach(Book book in Books)
            {
                Console.WriteLine(book.BookName);
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

        public void ShowBooksByCondition()
        {
            IEnumerable<Book> filteredList = this.Books.Where(b => b.BookYear >= 2017 && b.BookYear <= 2019);

            Console.WriteLine("Книги между 2017-2019 года");
            ShowAllBook(filteredList);
        }

        public void ShowBooksById(int id)
        {
            IEnumerable<Book> booksById = this.Readers.Where(r => r.Id == id).Select(r => r.HoldedBooks).FirstOrDefault();
            ShowAllBook(booksById);


        }
        public void DrunkStyle()
        {
            Console.WriteLine("Пьяные читатили:");
            foreach(Reader reader in Readers)
            {
                Console.WriteLine(reader.FirstName.Drunk() + " " + reader.LastName.Drunk());
                Console.WriteLine();

            }
        }

    }
}
