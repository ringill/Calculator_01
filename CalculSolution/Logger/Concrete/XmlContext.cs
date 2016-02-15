using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Logger.Entities;

namespace Logger.Concrete
{
    public class XmlContext
    {
        public string FileName { get; private set; }
        public XDocument Document { get; private set; }

        public XmlContext()
        {
            //Read Path
            FileName = ConfigurationManager.AppSettings["XmlFilePath"];
            //Create file if it not exists
            var file = new FileInfo(this.FileName);
            if (!file.Exists)
            {
                Document = new XDocument();
                XElement element = new XElement("Records");
                Document.Add(element);
                Document.Save(this.FileName);
            }
            else
            {
                Document = XDocument.Load(this.FileName);
            }
        }

        public void Add(Record record)
        {
            XElement element = new XElement("Record");
            element.Add(new XAttribute("When",record.When));
            element.Add(new XAttribute("What", record.What));
            Document.Root.Add(element);
        }

        public void SaveChanges()
        {
            Document.Save(this.FileName);
        }
    }
}
