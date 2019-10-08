using LibraryTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryTask.Menu
{
    public class MenuItem
    {
        public string Description { get; set; }
        public Action Execute { get; set; }
    }
}
