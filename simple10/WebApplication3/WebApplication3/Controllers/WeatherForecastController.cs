using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NetTopologySuite.Geometries;
using NetTopologySuite.Operation.Distance;
using NetTopologySuite.Utilities;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using WebApplication3.Domain;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private EFDbContext _eFDbContext;

        public WeatherForecastController(EFDbContext eFDbContext)
        {
            _eFDbContext = eFDbContext;
        }

        [HttpGet("get1")]
        public async Task<string> Get()
        {
            var p = new Pub("aa", new string[] { "1", "2" });
            p.DaysVisited.Add(DateOnly.FromDateTime(DateTime.Now));
            _eFDbContext.Pubs.Add(p);

            // 创建一个新的 Blog 实体
            var dic = new Dictionary<string, object>
            {
                { "BlogId", 1 },
                { "Url", "https://example.com" },
                { "LastUpdated", DateTime.Now }
            };
            _eFDbContext.Blogs.Add(dic);

            _eFDbContext.SaveChanges();




            return "";
        }
        [HttpGet("get2")]
        public async Task<string> Get1()
        {
            //_eFDbContext.Locations.Add(new Domain.Location { Name = "Bangalore", Position = new Point(12.9715987, 77.5945627) { SRID = 4326 } });
            //_eFDbContext.Locations.Add(new Domain.Location { Name = "Mumbai", Position = new Point(19.0760, 72.8777) { SRID = 4326 } });
            
            //_eFDbContext.SaveChanges();

            return "";
        }

        [HttpGet("get3")]
        public async Task<string> Get3()
        {
            // Define the user's current location
            //var userLocation = new Point(13.0827, 80.2707) { SRID = 4326 }; // Example coordinates (Chennai, India)

            //// Query to find all locations sorted by distance from the user's location
            //var sortedLocations = _eFDbContext.Locations
            //    .OrderBy(l => l.Position.Distance(userLocation))
            //    .ToList();

            //// Display the results
            //foreach (var location in sortedLocations)
            //{
            //    var distance = location.Position.Distance(userLocation); // Distance in meters
            //    Console.WriteLine($"Id: {location.Id}, Name: {location.Name}, Position: {location.Position}, Distance: {distance} meters");
            //}

            return "";

        }

        [HttpGet("get4")]
        public async Task<string> Get4()
        {
            // 使用相同的查询上下文来验证
            var query = _eFDbContext.Cities.AsNoTracking().Where(r => r.CityID == 1);

            var model = await query.FirstOrDefaultAsync();
            var model2 = await query.FirstOrDefaultAsync();

            bool areSameInstance = ReferenceEquals(model, model2); 
            return areSameInstance.ToString();
        }
        [HttpGet("get5")]
        public async Task<string> Get5()
        {
            // 使用相同的查询上下文来验证
            var query = _eFDbContext.Cities.AsNoTrackingWithIdentityResolution().Where(r => r.CityID == 1);

            var model =  query.FirstOrDefault();
            var model2 =  query.FirstOrDefault();

            bool areSameInstance = ReferenceEquals(model, model2); 
            return areSameInstance.ToString();
        }
        [HttpGet("get7")]
        public async Task<string> Get7(string test)
        {
            var model = await _eFDbContext.Cities.FirstOrDefaultAsync(r => r.CityID == 1);
            model.CityNameCode = test;

            Thread.Sleep(10000);
            await _eFDbContext.SaveChangesAsync();
            return "";
        }
        [HttpGet("get6")]
        public async Task<string> Get6(string test)
        {
            _eFDbContext.BBBBlogs
    .Select(b => new { Blog = b, NewRating = b.Posts.Average(p => p.Id) })
    .ExecuteUpdate(setters => setters.SetProperty(b => b.Blog.OwnerId, b => b.NewRating));

            //_eFDbContext.BBBBlogs.ExecuteUpdate(r => r.SetProperty(m => m.OwnerId, m => m.Posts.Average(x=>x.Id)));
            return "";
        }
        [HttpGet("get9")]
        public async Task<string> Get9(string test)
        {
            _eFDbContext.BBBBlogs.Add(new BBBBlog() { 
            Name="1",
            Id=1,
            OwnerId=1,
            Posts=new List<Post>() { 
                new Post() {AuthorId=1,Content="1",Id=1,Title="1"},
                new Post() {AuthorId=2,Content="2",Id=2,Title="2"}
            }
            });

            _eFDbContext.SaveChanges();
            return "";
        }
        [HttpGet("get8")]
        public async Task<List<City>> Get8(int test)
        {
            var model =  _eFDbContext.Cities.FromSqlRaw($"select * from cities").Where(r=>r.CityID==test).ToList();
            return model;
        }
        [HttpGet("get10")]
        public async Task Get10(int test)
        {
            using var transcation = _eFDbContext.Database.BeginTransaction();
            try
            {
                _eFDbContext.BBBBlogs.Add(new BBBBlog()
                {
                    Name = "2",
                    Id = 2,
                    OwnerId = 2,

                });

                _eFDbContext.SaveChanges();
                transcation.CreateSavepoint("BeforeMoreBlogs");
                _eFDbContext.BBBBlogs.Add(new BBBBlog()
                {
                    Name = "3",
                    Id = 3,
                    OwnerId = 3,

                });
                _eFDbContext.BBBBlogs.Add(new BBBBlog()
                {
                    Name = "4",
                    Id = 3,
                    OwnerId = 4,

                });


                _eFDbContext.SaveChanges();

                transcation.Commit();

            }
            catch (Exception ex)
            {
                transcation.RollbackToSavepoint("BeforeMoreBlogs");
            }
            //由于设置了保存点，Id = 2的数据会在下面transcation.Commit()进行保存
            transcation.Commit();
        }

        [HttpGet("get11")]
        public async Task Get11()
        {
            var aa = new BBBBlog()
            {
                Id = 2,
                OwnerId = 2,
            };

           var blog= _eFDbContext.BBBBlogs.Where(r => r.Id == 2).FirstOrDefault();
            _eFDbContext.Entry(blog).CurrentValues.SetValues(aa);

            _eFDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);

            _eFDbContext.SaveChanges();
        }
        [HttpGet("get12")]
        public async Task Get12()
        {
          
            var blog1 = _eFDbContext.BBBBlogs.Where(r => r.Id == 1).Include(r=>r.Posts).FirstOrDefault();
            var post= blog1.Posts.FirstOrDefault();

            var blog2 = _eFDbContext.BBBBlogs.Where(r => r.Id == 2).FirstOrDefault();
            blog1.Posts.Remove(post);
            blog2.Posts.Add(post);

            _eFDbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);
            _eFDbContext.SaveChanges();
        }

        [HttpGet("get13")]
        public async Task Get13()
        {
          var aaa=  _eFDbContext.BBBBlogs.Include(e=>e.Posts).ToList();
            var a= JsonConvert.SerializeObject(aaa, new JsonSerializerSettings
            {
                //表示在序列化过程中忽略循环引用，这样可以避免由于循环引用导致的序列化错误或无限递归。
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented//美化jso
            });
            Console.WriteLine(a);
        }

        [HttpGet("get14")]
        public async Task Get14()
        {
            //var aaa = _eFDbContext.Post.Include(e => e.Blog).ToList();
            //var a = JsonConvert.SerializeObject(aaa, new JsonSerializerSettings
            //{
            //    //启用对象引用保留处理。这意味着，如果对象图中存在循环引用（例如，一个 Post 对象引用了一个 Blog 对象，而这个 Blog 对象又引用了该 Post 对象）
            //    //，则序列化时会保留这些引用，以避免无限递归。这通常会添加 $id 和 $ref 字段到 JSON 中来标识和引用这些对象
            //    PreserveReferencesHandling = PreserveReferencesHandling.All,
            //    Formatting = Formatting.Indented//美化json
            //});
            var adress = new Address() { City = "000", Country = "000", Line1 = "000", PostCode = "000" };
            var order = new Order()
            {
                Customer = new Customer() { 
                    Address = adress,
                    Name = "000"
                },
                Contents = "000",
                BillingAddress = adress,
                ShippingAddress = adress
            };
            //_eFDbContext.Orders.Add(order);
            _eFDbContext.SaveChanges();
        }

        [HttpGet("get15")]
        public async Task Get15()
        {
            //var a= _eFDbContext.Blogs.TagWith("Use hint: robust plan").ToList();
        }

        [HttpPost]
        public ActionResult AddBlog(string name)
        {
            _eFDbContext.BBBBlogs.Add(new BBBBlog { Name = name,Url="bb"});

            _eFDbContext.ChangeTracker.DetectChanges();
            Debug.WriteLine(_eFDbContext.ChangeTracker.DebugView.LongView);

            _eFDbContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBlog(string name,string url)
        {
            var blog = _eFDbContext.BBBBlogs.Where(r => r.Name == name).FirstOrDefault();
            blog.Url = url;

            _eFDbContext.SaveChanges();

            return Ok();
        }

    }
}
