using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtDemo.Controllers
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
        [HttpGet]
        [Authorize]
        public string Get()
        {
            return HttpContext.User.Identity.Name ?? "";
        }

        [HttpGet]
        [Route("login")]
        public async Task Login()
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>(){
                new Claim(ClaimTypes.Name,"1")
                }, OpenIdConnectDefaults.AuthenticationScheme);
            var ident = new System.Security.Claims.ClaimsPrincipal(new List<ClaimsIdentity>() {
              claimsIdentity
            });
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }
    }
}
