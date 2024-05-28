using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DemoController : ControllerBase
    {
        private IScopedService _scopedService;

        public DemoController(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }
        public string Get()
        {
            return "get-" + _scopedService.Get();
        }
    }
}
