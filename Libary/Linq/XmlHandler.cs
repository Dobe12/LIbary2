using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using LibaryTask;
using LibraryTask.Models;

namespace LibraryTask.Linq
{
    public class XmlHandler
    {
        private string _path;

        public XmlHandler(string path)
        {
            if (ifExists(path))
                _path = path;
        }
        public void AddDataToLibrary(Library library)
        {

            Dictionary<string, IEnumerable<XElement>> elementsFromXml = XmlGetData(this._path, library);

            library.AddDataToLibrary(elementsFromXml);
        }
        static bool ifExists(string path)
        {
            return File.Exists(path);
        }
    
        private static Dictionary<string, IEnumerable<XElement>> XmlGetData(string path, Library libary)
        {
            XDocument xdoc = XDocument.Load(path);

            Dictionary <string, IEnumerable <XElement>> listElements = new Dictionary<string,  IEnumerable < XElement > > ();

            IEnumerable<XElement> booksElements = xdoc.Element("library").Element("books").Elements();
            IEnumerable<XElement> readerElements = xdoc.Element("library").Element("readers").Elements();

            listElements.Add("Books", booksElements);
            listElements.Add("Readers", readerElements);

            return listElements;
        }


    }
}
