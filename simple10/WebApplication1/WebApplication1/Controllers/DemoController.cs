using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DemoController:ControllerBase
    {
        private ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }
        [HttpGet("get1")]
        public string Get()
        {
            return "get1";
        }
        [HttpGet("get2")]
        public string Get2()
        {
            return "get2";
        }
        [HttpGet("get3/{i}")]
        //[Route()]
        public string Get3(int i)
        {
            return "Get3"+i.ToString();
        }
        [HttpGet("get4")]
        public string Get4(int i)
        {
            return "Get4" + i.ToString();
        }

        [HttpGet("get5")]
        public string Get5(int i)
        {
            _logger.LogInformation("qqq");
            return "get5";
        }
    }
}
