using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using LibaryTask.Models;

namespace LibaryTask.Linq
{
    public class XmlHandler
    {
        public string _path;
        Libary _libary { get; set; }


        public XmlHandler(string path)
        {
            _path = path;
            _libary = new Libary();

        }


        public void Start()
        {
            List<IEnumerable<XElement>> elementsFromXml = XmlGetData(this._path, this._libary);

            _libary.addDataToLibary(elementsFromXml);
            _libary.showBooksByCondition();
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
