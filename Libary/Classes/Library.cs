using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace LibraryTask.Models
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Reader> Readers { get; set; } = new List<Reader>();

        public  void AddDataToLibrary(Dictionary<string, IEnumerable<XElement>> elements)
        {
            foreach (XElement element in elements["Books"])
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
                else
                {
                    throw new Exception("Bad data in Books");
                }
            }

            foreach (XElement element in elements["Readers"])
            {
                if (element.Name == "reader")
                {
                    List<Book> holdedBooks = new List<Book>();
                    foreach (XElement bookHoldedElement in element.Elements("holdedBooks"))
                    {
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
                } else
                {
                    throw new Exception("Bad data in Readers");
                }
            }                            
        }
    }
}
