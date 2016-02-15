using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Entities;

namespace Logger.Abstract
{
    public interface IRepository
    {
        bool Add(string rec);
        IEnumerable<Record> Get5(int n = 5);
    }
}
