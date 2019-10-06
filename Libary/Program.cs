using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using LibaryTask.Models;
using LibaryTask.Linq;

namespace LibaryTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string _path = @"Library.xml";

            XmlHandler xmlhandler = new XmlHandler(_path);
            xmlhandler.Start();

            Console.Read();
        }


        

       

        
      
    }
}
