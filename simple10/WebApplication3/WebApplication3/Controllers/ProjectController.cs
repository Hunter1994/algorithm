using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Domain;

namespace WebApplication3.Controllers
{
    public class ProjectController
    {
        private EFDbContext _eFDbContext;

        public ProjectController(EFDbContext eFDbContext)
        {
            _eFDbContext = eFDbContext;
        }

        [HttpGet("get1")]
        public async Task<string> Get1()
        {
            var bb = _eFDbContext.BBBBlogs.ToList();
            _eFDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);

            return "";
        }

        [HttpGet("get2")]
        public async Task<string> Get2()
        {
            var bb = _eFDbContext.BBBBlogs.AsQueryable().AsNoTracking().ToList();
            _eFDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);

            foreach (var item in bb)
            {
                _eFDbContext.Entry<BBBBlog>(item).State = EntityState.Unchanged;
                item.Name = "4";
            }
            _eFDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);
            _eFDbContext.SaveChanges();
            return "";
        }

        [HttpGet("get3")]
        public async Task<List<BBBBlog>> Get3()
        {
            var bb = _eFDbContext.BBBBlogs.AsQueryable().AsNoTracking().ToList();
            return bb;
        }

    }
}
