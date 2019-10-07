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
    }
}
