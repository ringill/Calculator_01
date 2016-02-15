using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinFu.IoC.Configuration;
using LinFu.IoC.Interfaces;
using Logger.Abstract;
using Logger.Entities;

namespace Logger.Concrete
{
    [Implements(typeof(ISqlRepository), LifecycleType.OncePerRequest)]
    public class EFRepository : ISqlRepository
    {
        private EFDbContext db = new EFDbContext();

        /// <summary>
        /// Save record into log
        /// </summary>
        /// <param name="rec"></param>
        /// <returns></returns>
        public bool Add(string rec)
        {
            //build record
            var record = new Record
                {
                    What = rec,
                    When = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss")
                };
            //add record to database
            db.Records.Add(record);
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
        /// Get n records
        /// </summary>
        /// <param name="n">record count</param>
        /// <returns></returns>
        public IEnumerable<Record> Get5(int n)
        {
            //order by Id and get last five records
            return db.Records.Count() < n ? db.Records : db.Records.OrderBy(rec => rec.Id).Skip(Math.Max(0, db.Records.Count() - n)).Take(n);
            //it's my hint:
            //collection.Skip(Math.Max(0, collection.Count() - N)).Take(N);
        }
    }
}
