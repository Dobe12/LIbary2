using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using LibraryTask.Models;
using LibraryTask.Linq;
using LibaryTask;

namespace LibraryTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string _path = @"Library.xml";

                XmlHandler xmlhandler = new XmlHandler(_path);

                Library library = new Library();
                xmlhandler.AddDataToLibrary(library);

                ComandList comand = new ComandList(library);

                comand.MenuStart();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }      
    }
}
