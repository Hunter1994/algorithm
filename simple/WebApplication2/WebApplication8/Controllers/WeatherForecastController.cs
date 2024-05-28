using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace WebApplication8.Controllers
{
    [ApiController]
    [Route("{controller:slugify}")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public IEnumerable<WeatherForecast> Get(string id)
        {
            var transactionId = Guid.NewGuid().ToString();

            using (_logger.BeginScope(new List<KeyValuePair<string, object>>
            {
            new KeyValuePair<string, object>("TransactionId", transactionId),
        }))
            {
                _logger.LogInformation("LogInformation");
                _logger.LogError("LogError");
            }
            _logger.LogInformation("LogInformation1");
            _logger.LogError("LogError1");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
