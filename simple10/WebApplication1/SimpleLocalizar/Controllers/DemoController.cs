using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SimpleLocalizar;
using System.Globalization;

namespace SimpleLocalizar.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DemoController : ControllerBase
    {
        private IStringLocalizer<ShardResource> _stringLocalizer;

        public DemoController(IStringLocalizer<ShardResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        [HttpGet]
        [Route("get1")]
        public string Get1()
        {
            return $"c:{CultureInfo.CurrentCulture};c-ui:{CultureInfo.CurrentUICulture}¡£username:{_stringLocalizer["UserName"]}";
        }
        [HttpGet]
        [Route("/{culture}/[controller]/get2")]
        public string Get2()
        {
            return $"c:{CultureInfo.CurrentCulture};c-ui:{CultureInfo.CurrentUICulture}¡£username:{_stringLocalizer["UserName"]}";
        }

    }
}
