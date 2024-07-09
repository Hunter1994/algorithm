using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
//using StringLocalizerLibrary;
using System.Globalization;

namespace StringLocalizerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IStringLocalizer<WeatherForecastController> _stringLocalizer;

        public WeatherForecastController(IStringLocalizer<WeatherForecastController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet("/{culture}/[controller]")]
        public string Get()
        {
            var a= CultureInfo.CurrentCulture;
            return a+","+_stringLocalizer["UserName"];
        }

        [HttpGet("get2")]
        public string Get2()
        {
            var a = CultureInfo.CurrentCulture;
            
            return a + "," + _stringLocalizer["UserName"];
        }


        [HttpGet("/{local}/[controller]/get3")]
        public string Get3()
        {
            var a = CultureInfo.CurrentCulture;
            return a + "," + _stringLocalizer["UserName"];
        }
    }
}
