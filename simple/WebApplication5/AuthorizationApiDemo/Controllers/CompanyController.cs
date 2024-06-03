using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController:ControllerBase
    {
        [HttpGet]
        [Route("Get1")]
        public string Get1()
        {
            var a = HttpContext.User;
            return "company1";
        }

        [HttpGet]
        [Route("Get2")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public string Get2()
        {
            var a = HttpContext.User;
            return "company2";
        }
    }
}
