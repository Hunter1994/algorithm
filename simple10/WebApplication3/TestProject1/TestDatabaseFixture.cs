using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication3;
using WebApplication3.Domain;

namespace TestProject1
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"server=localhost; port=3306;uid=root;pwd=123456;Database=efdemo1;Convert Zero Datetime=True;";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context.AddRange(
                        new BBBBlog { Name = "Blog1",Url="aa"},
                            new BBBBlog { Name = "Blog2",Url="aa"});
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        //public EFDbContext CreateContext()
        //    => new EFDbContext(
        //        new DbContextOptionsBuilder<EFDbContext>()
        //            .UseMySql(ConnectionString, new MySqlServerVersion("5.7.0"))
        //            .Options);
        public EFDbContext CreateContext()
            =>throw new NotImplementedException();
    }
}
