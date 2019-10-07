using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using LibraryTask.Models;

namespace LibraryTask.Linq
{
    public class XmlHandler
    {
        public string _path;
        Libary _library { get; set; }


        public XmlHandler(string path)
        {
            _path = path;
            _library = new Libary();

        }


        public void Start()
        {
            List<IEnumerable<XElement>> elementsFromXml = XmlGetData(this._path, this._library);

            _library.AddDataToLibary(elementsFromXml);

            ComandList comand = new ComandList(_library);
            comand.MenuStart();

        }
        static bool isExists(string path)
        {
            return File.Exists(path);
        }

        

        private static List<IEnumerable<XElement>> XmlGetData(string path, Libary libary)
        {
            if (!isExists(path))
                throw new Exception("Неверный путь");

            XDocument xdoc = XDocument.Load(path);

            List<IEnumerable<XElement>> listElements = new List<IEnumerable<XElement>>();

            IEnumerable<XElement> booksElements = xdoc.Element("library").Element("books").Elements();
            IEnumerable<XElement> readerElements = xdoc.Element("library").Element("readers").Elements();

            listElements.Add(booksElements);
            listElements.Add(readerElements);

            return listElements;
        }


    }
}
