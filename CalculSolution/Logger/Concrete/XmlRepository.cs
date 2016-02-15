using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinFu.IoC.Configuration;
using Logger.Abstract;
using Logger.Entities;

namespace Logger.Concrete
{
    [Implements(typeof(IXmlRepository), LifecycleType.OncePerRequest)]
    public class XmlRepository : IXmlRepository
    {
        private XmlContext db = new XmlContext();

        public bool Add(string rec)
        {
            //build record
            var record = new Record
            {
                What = rec,
                When = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")
            };
            //add record to xml file
            db.Add(record);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get lact five records from xml
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Record> Get5(int n)
        {
            //get last five elements and convert its into records
            var res = db.Document.Root.Elements().Skip(Math.Max(0, db.Document.Elements().Count() - n)).Take(n)
                .Select(xmlElement => new Record
                    {
                        When = xmlElement.Attribute("When").Value,
                        What = xmlElement.Attribute("What").Value
                    });

            return res;
            //it's my hint:
            //collection.Skip(Math.Max(0, collection.Count() - N)).Take(N);
        }
    }
}
