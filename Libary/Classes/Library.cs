using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace LibraryTask.Models
{
    public class Libary
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Reader> Readers { get; set; } = new List<Reader>();


        public  void addDataToLibary(List<IEnumerable<XElement>> list)
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
                        List<Book> bookHolded = new List<Book>();
                        foreach(XElement bookElement in element.Elements("bookHolded"))
                        {
                            //обработать!
                           //Convert.ToInt32(bookElement.Attribute("id").Value
                           // bookHolded.Add(this.Books.Where(b));
                           // Convert.ToInt32(bookElement.Attribute("id").Value);
                           // Convert.ToInt32(bookElement.Attribute("id").Value
                        }
                        this.Readers.Add(new Reader
                        {
                            FirstName = element.Attribute("FirstName").Value,
                            LastName = element.Attribute("LastName").Value,
                            Id = Convert.ToInt32(element.Attribute("id").Value),
                            DateOfBirth = Convert.ToDateTime(element.Attribute("DateOfBirth").Value)

                        });
                    }
                    else
                    {
                        throw new Exception("Ошибочный элемент");
                    }


                }
            }

        }
        public void showAllBookNames()
        {
            foreach(Book book in Books)
            {
                Console.WriteLine(book.BookName);
            }
        }

        private static void showAllBook(IEnumerable<Book> filteredList)
        {
            foreach (Book book in filteredList)
            {
                Console.WriteLine($"Автор: {book.BookAuthor}");
                Console.WriteLine($"Название: {book.BookName}");
                Console.WriteLine($"Год выпуска: {book.BookYear} \n");
            }
        }

        public void showBooksByCondition()
        {
            IEnumerable<Book> filteredList = this.Books.Where(b => b.BookYear >= 2017 && b.BookYear <= 2019);

            Console.WriteLine("Книги между 2017-2019 года");
            showAllBook(filteredList);
        }

        public void showBooksById(int id)
        {
            
        }
        public void drunkStyle()
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
