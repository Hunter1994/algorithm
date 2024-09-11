using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EfDesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfDbContext>
    {
        public EfDbContext CreateDbContext(string[] args)
        {
            var configure = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

            var build = new DbContextOptionsBuilder<EfDbContext>();
            build.UseMySql(configure.GetConnectionString("Default"), new MySqlServerVersion("5.6"));
            return new EfDbContext(build.Options);

        }


    }
}
