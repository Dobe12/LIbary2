using System;
using System.Collections.Generic;
using System.Text;
using LibraryTask;
using LibraryTask.Models;

namespace LibaryTask.Menu
{
    class ShowwNamesByDrunkStyle : IMenu
    {
        private string Description = " 4 - Вывести список всех названий книг ";
        public void Start(Library library)
        {
            Console.WriteLine("Пьяные читатели:");
            foreach (Reader reader in library.Readers)
            {
                Console.WriteLine(reader.FirstName.Drunk() + " " + reader.LastName.Drunk());
                Console.WriteLine();
            }
        }
    }
}
