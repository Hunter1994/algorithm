using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DemoDbContext:DbContext
    {
        public DbSet<XmlKey> XmlKeys { get; set; }
        public DemoDbContext()
        { 
        }
        public DemoDbContext(DbContextOptions options) : base(options)
        { 
        }


    }
}
