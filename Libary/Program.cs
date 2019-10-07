using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using LibraryTask.Models;
using LibraryTask.Linq;

namespace LibraryTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string _path = @"C:\Users\1\Source\Repos\Libary\Libary\bin\Debug\netcoreapp2.1\Library.xml";

            XmlHandler xmlhandler = new XmlHandler(_path);
            xmlhandler.Start();

            Console.WriteLine("wfwefwef".Drunk());


            Console.Read();
        }


        

       

        
      
    }
}
