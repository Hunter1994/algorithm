using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApplication3.Domain;

namespace WebApplication3
{
    public class EFDbContext:DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pub> Pubs { get; set; }
        public virtual TenantId TenantId {  get; set; }
        public DbSet<Dictionary<string, object>> Blogs => Set<Dictionary<string, object>>("Blog");
        public DbSet<Rider> Riders { get; set; }

        public DbSet<City> Cities { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<Location> Locations { get; set; }
        public DbSet<NullSemanticsEntity> NullSemantics { get; set; }
        public DbSet<BBBBlog> BBBBlogs { get; set; }
        public DbSet<Post> Post { get; set; }

        public EFDbContext() { 
        }
        public EFDbContext(DbContextOptions<EFDbContext> options, IConfiguration config, ITenantService tenantService) : base(options)
        {
            _config = config;
            _tenantService = tenantService;
        }

        private static readonly TaggedQueryCommandInterceptor taggedQueryCommandInterceptor = new TaggedQueryCommandInterceptor();
        private IConfiguration _config;
        private ITenantService _tenantService;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("1111111111111111");
            var tenant = _tenantService.Tenant;
            var connectionStr = _config.GetConnectionString(tenant);
            optionsBuilder.UseMySql(connectionStr, new MySqlServerVersion("5.6"));

            optionsBuilder.AddInterceptors(taggedQueryCommandInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SharedTypeEntity<Dictionary<string, object>>(
                "Blog", bb =>
                {
                    bb.Property<int>("BlogId");
                    bb.Property<string>("Url");
                    bb.Property<DateTime>("LastUpdated");
                });

            modelBuilder
        .Entity<Rider>()
        .Property(e => e.Mount)
        .HasConversion(
            v => v.ToString(),
            v => (EquineBeast)Enum.Parse(typeof(EquineBeast), v));


            modelBuilder.Entity<City>().Property<byte[]>("version").IsRowVersion();

            modelBuilder.Ignore<Location>();
            modelBuilder.Ignore<City>();

        }

    }
}
