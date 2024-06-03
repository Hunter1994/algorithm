using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private IAuthorizationService _authorizationService;

        public ProjectController(IAuthorizationService authorizationService) {
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Route("Get1")]
        [Authorize(Policy = "Get1")]
        public string Get1()
        {
            return "project1";
        }
        [HttpGet]
        [Route("Get2")]
        [Authorize(Policy = "Get2")]
        public string Get2()
        {
            return "project2";
        }
        [HttpGet]
        [Route("Get3")]
        [Authorize(Policy = "Get3")]
        public string Get3()
        {
            return "project3";
        }
        [HttpGet]
        [Route("Get4")]
        [AllowAnonymous]
        public string Get4()
        {
            return "project3-" + HttpContext.User.Identity.Name ?? "";
        }
        [HttpGet]
        [Route("Get5")]
        [Authorize(Roles ="admin")]
        public string Get5()
        {
            return "project3-" + HttpContext.User.Identity.Name ?? "";
        }
        [HttpGet]
        [Route("Get6")]
        public async Task<string> Get6()
        {
            var res=await _authorizationService.AuthorizeAsync(HttpContext.User, "Get6");
            if (res.Succeeded)
                return "project3-" + HttpContext.User.Identity.Name ?? "";
            else return "Î´ÊÚÈ¨";
        }

        [HttpGet]
        [Route("Get7")]
        [Authorize(Policy = "Set7")]
        public async Task<string> Get7()
        {
            return "project3-" + HttpContext.User.Identity.Name ?? "";
        }
    }
}
