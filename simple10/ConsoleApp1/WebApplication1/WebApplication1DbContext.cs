using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class WebApplication1DbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<XmlKey> XmlKeys { get; set; }

        public WebApplication1DbContext() { 
        }
        public WebApplication1DbContext(DbContextOptions options):base(options) { }
    }
}
