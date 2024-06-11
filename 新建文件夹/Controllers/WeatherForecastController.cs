using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

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
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly WebApplication1DbContext _dbContext;
        private readonly BearerTokenOptions _options;
        private readonly IAuthenticationHandlerProvider _authenticationHandlers;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            SignInManager<IdentityUser> signInManager,
            WebApplication1DbContext dbContext, IOptions<BearerTokenOptions> options,
            IAuthenticationHandlerProvider authenticationHandlers,
            IDataProtectionProvider dataProtectionProvider)
        {
            _logger = logger;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _options = options.Value;
            _authenticationHandlers = authenticationHandlers;
            _dataProtectionProvider = dataProtectionProvider;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task Get()
        {
            //var aa = _dbContext.Users.ToList();
            //_signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            //var result = await _signInManager.PasswordSignInAsync("123@qq.com", "1q2w3E~", false, lockoutOnFailure: true);


            //if (!result.Succeeded)
            //{
            //    return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
            //}


            //// The signInManager already produced the needed response in the form of a cookie or bearer token.
            //return TypedResults.Empty;

            var aaa = new ClaimsPrincipal(new List<ClaimsIdentity>() {
                new ClaimsIdentity(new List<Claim>(){ new Claim(ClaimTypes.Name,"123@qq.com") },IdentityConstants.BearerScheme)
             }
            );
            await HttpContext.SignInAsync(IdentityConstants.BearerScheme, aaa);

            // var t = new AuthenticationTicket(aaa, IdentityConstants.BearerScheme);
            //var aa=  _options.BearerTokenProtector.Protect(t);
            // return aa;
        }

        [Route("get1")]
        [Authorize(AuthenticationSchemes= "Identity.Bearer")]
        [HttpGet]
        public async Task<string> Get(string str)
        {
            var aa12131= HttpContext.User;

            var aaa = GetBearerTokenOrNull();
            var aaaaa = _authenticationHandlers;
            var bb =await aaaaa.GetHandlerAsync(HttpContext, IdentityConstants.BearerScheme);
            var bbb= bb as AuthenticationHandler<BearerTokenOptions>;

            var aa = bbb.Options.BearerTokenProtector.Unprotect(aaa);


            var p= _dataProtectionProvider.CreateProtector("Microsoft.AspNetCore.Authentication.BearerToken").CreateProtector("Identity.Bearer").CreateProtector( "BearerToken");


            //var protectedData = Base64UrlTextEncoder.Decode(aaa);
            var aa2 = p.Unprotect(aaa);



            return aa.Principal.Identity.Name;
        }
      
        private string? GetBearerTokenOrNull()
        {
            var authorization = Request.Headers.Authorization.ToString();

            return authorization.StartsWith("Bearer ", StringComparison.Ordinal)
                ? authorization["Bearer ".Length..]
                : null;
        }

    }
}
