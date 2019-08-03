using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmta.domain;

namespace wmta.Infrustructure
{
    public class WMDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
    }
}
