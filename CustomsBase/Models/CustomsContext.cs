using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CustomsBase.Models
{
    public class CustomsContext:DbContext
    {
        public CustomsContext(DbContextOptions<CustomsContext> options):base(options)
        {
        }
        public DbSet<Customs_agents> Customs_agents { get; set; }
        public DbSet<Customs_werehouses> Customs_werehouses { get; set; }
        public DbSet<Type_of_Good> Types_of_goods { get; set; }
        public DbSet<Duti> Duties { get; set; }

    }
}
