using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public  async Task<IEnumerable<WeatherForecast>> Get()
        {

            //var a = _httpClientFactory.CreateClient("demo");
            //a.DefaultRequestHeaders.Add("X-TraceId", "111111111111111");
            //var res=await a.GetAsync("WeatherForecast");
            //var aaa = res.Headers.GetValues("X-TraceId");
            //var str= res.Content.ReadAsStringAsync();


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public string Post(Model m)
        {
            return JsonSerializer.Serialize(m);
        }

    }

    public class Model
    { 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
