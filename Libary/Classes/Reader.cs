using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Book> HoldedBooks { get; set; }
    }
}
