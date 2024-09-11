using System.Diagnostics;
using WebApplication3.Controllers;
using Xunit;

namespace TestProject1
{
    public class UnitTest1: IClassFixture<TestDatabaseFixture>
    {
        public UnitTest1(TestDatabaseFixture fixture)
       => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }
        [Fact]
        public void Test1()
        {

            using var context = Fixture.CreateContext();

            var b= context.BBBBlogs.Where(r => r.Name == "Blog1").FirstOrDefault();
            Assert.Equal("aa", b.Url);
        }

        [Fact]
        public void AddBlog()
        {
            using var context = Fixture.CreateContext();
            context.Database.BeginTransaction();

            var controller = new WeatherForecastController(context);
            controller.AddBlog("Blog3");

            context.ChangeTracker.DetectChanges();
            Debug.WriteLine(context.ChangeTracker.DebugView.LongView);

            context.ChangeTracker.Clear();

            context.ChangeTracker.DetectChanges();
            Debug.WriteLine(context.ChangeTracker.DebugView.LongView);
            var blog = context.BBBBlogs.Single(b => b.Name == "Blog3");
            Assert.Equal("Blog3", blog.Name);

        }
        [Fact]
        public void UpdateBlog()
        {
            using var context = Fixture.CreateContext();
            //context.Database.BeginTransaction();

            var controller = new WeatherForecastController(context);
            controller.UpdateBlog("Blog1", "11");
            var blog = context.BBBBlogs.Single(b => b.Name == "Blog1");
            Assert.Equal("11", blog.Url);
        }

        [Fact]
        public void Test3()
        {
            using var context = Fixture.CreateContext();
            var b = context.BBBBlogs.Where(r => r.Name == "Blog1").FirstOrDefault();
            Assert.Equal("aa", b.Url);
        }
    }
}