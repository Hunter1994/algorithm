using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 10)]
        public string Get()
        {
            return DateTime.Now.ToString();
        }
    }
}
