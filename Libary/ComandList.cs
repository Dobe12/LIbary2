using LibraryTask.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryTask
{
    class ComandList
    {
        public Library library { get; set; }
        //public List<Tuple<string,Action>>;

        public ComandList(Library library)
        {
            this.library = library;
        }
        public  void MenuStart()
        {
            bool alive = true;

            while(alive)
            {
                Console.WriteLine("1 - Вывести список всех названий книг");
                Console.WriteLine("2 - Вывести все книги, изданные между 2017 и 2019 годом");
                Console.WriteLine("3 - Вывести книги, которые взяла Дашкова");
                Console.WriteLine("4 - Получить пьяный список ФИО читателе");
                Console.WriteLine("5 - Выход");

                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            library.ShowAllBookNames();
                            break;
                        case 2:
                            library.ShowBooksByCondition();
                            break;
                        case 3:
                            library.ShowBooksById(2);
                            break;
                        case 4:
                            library.DrunkStyle();
                            break;
                        case 5:
                            alive = false;
                            continue;
                    }

                }
                catch (Exception ex)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = Console.ForegroundColor;
                }
            }
        }
            
    }
}
