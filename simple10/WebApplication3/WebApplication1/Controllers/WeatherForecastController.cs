using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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
        private readonly ServiceDiscoveryClient _serviceDiscoveryClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ServiceDiscoveryClient serviceDiscoveryClient)
        {
            _logger = logger;
            _serviceDiscoveryClient = serviceDiscoveryClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            var services = await _serviceDiscoveryClient.GetServicesAsync();
            var myService = services.FirstOrDefault(s => s.Service == "my-service");

            if (myService != null)
            {
                var serviceUrl = $"https://{myService.Address}:{myService.Port}/WeatherForecast/Get2";
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(serviceUrl);
                Console.WriteLine(response);
            }
            return "";
        }
        [HttpGet("get2")]
        public async Task<string> Get2()
        {
            return "get2";
        }
    }
}
