using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController:ControllerBase
    {
        [HttpGet]
        public string Get(string str)
        {
            return str;
        }
    }
}
