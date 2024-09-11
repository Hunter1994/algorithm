using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EfDbContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Company1> Companies1 { get; set; }
        public DbSet<Company2> Companies2 { get; set; }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        { 
        }

    }
}
