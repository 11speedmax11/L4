using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace L4
{
    public  class ApplicationContext: DbContext
    {
        public ApplicationContext() : base("DefaultConnection") { }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
