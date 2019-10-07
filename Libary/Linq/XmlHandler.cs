using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LibaryTask;
using LibraryTask.Models;

namespace LibraryTask.Linq
{
    public class XmlHandler
    {
        private string _path;

        public XmlHandler(string path)
        {
            if (!ifExists(path)) { throw new Exception("Bad path"); }

            _path = path;
        }
        public void AddDataToLibrary(Library library)
        {
            FromXmlToObjectslist(XmlGetData(this._path, "books"), library);
            FromXmlToObjectslist(XmlGetData(this._path, "readers"), library);
        }
        static bool ifExists(string path)
        {
            return File.Exists(path);
        }
    
        private static IEnumerable<XElement> XmlGetData(string path, string item)
        {
            XDocument xdoc = XDocument.Load(path);

            IEnumerable<XElement> elements = xdoc.Element("library").Element(item).Elements();
  
            return elements;
        }


        static private void FromXmlToObjectslist(IEnumerable<XElement> elements, Library library)
        {
            foreach (XElement element in elements)
            {
                if (element.Name != "book" && element.Name != "reader") { throw new Exception("Bad data in Books"); }

                if (element.Name == "book")
                {
                    library.Books.Add(new Book
                    {
                        BookAuthor = element.Attribute("bookAuthor")?.Value,
                        BookName = element.Attribute("bookName")?.Value,
                        BookYear = Convert.ToInt32(element.Attribute("bookYear")?.Value),
                        Id = Convert.ToInt32(element.Attribute("id").Value)
                    });
                } else if(element.Name == "reader")
                {
                    List<Book> holdedBooks = new List<Book>();
                    foreach (XElement bookHoldedElement in element.Elements("holdedBooks"))
                    {
                        int id = Convert.ToInt32(bookHoldedElement.Element("bookHolded").Attribute("id").Value);
                        holdedBooks.Add(library.Books.Where(b => b.Id == id).FirstOrDefault());
                    }

                    library.Readers.Add(new Reader
                    {
                        FirstName = element.Attribute("FirstName").Value,
                        LastName = element.Attribute("LastName").Value,
                        Id = Convert.ToInt32(element.Attribute("id").Value),
                        DateOfBirth = Convert.ToDateTime(element.Attribute("DateOfBirth").Value),
                        HoldedBooks = holdedBooks
                    });
                }
            }
        }
    }
}
