using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class Get9Model
    {
        [Remote("VerifyUserName", "WeatherForecast")]
        public string UserName { get; set; }
    }
}
