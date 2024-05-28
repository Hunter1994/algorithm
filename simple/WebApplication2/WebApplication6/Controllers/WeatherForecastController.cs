using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
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
        private IConfiguration ConfigRoot;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configRoot)
        {
            _logger = logger;
            ConfigRoot=configRoot;
        }

        [HttpGet]
        public string Get()
        {
            var bb = ConfigRoot["BB"];

            //string str = "";
            //foreach (var provider in ConfigRoot.Providers.ToList())
            //{
            //    str += provider.ToString() + "\n";
            //}
            return bb;
        }
    }
}
