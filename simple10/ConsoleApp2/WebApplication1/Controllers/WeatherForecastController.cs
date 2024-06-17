using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize]
        public string Get()
        {
            return HttpContext.User.Identity.Name ?? "нч";
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Login()
        {
            await HttpContext.SignInAsync(new ClaimsPrincipal(new List<ClaimsIdentity>() {
               new ClaimsIdentity(new List<Claim> {new Claim(ClaimTypes.Name,"123@qq.com")},CookieAuthenticationDefaults.AuthenticationScheme)
            }));
        }

        [HttpPost]
        [Authorize]
        [Route("set")]
        public string Set([FromForm ]string a)
        {
            return "ok";
        }
        [DisableCors]
        [HttpOptions]
        [Route("delete")]
        public string Delete()
        {
            return "ok";
        }
    }
}
