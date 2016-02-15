using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Entities;

namespace Logger.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
    }
}
