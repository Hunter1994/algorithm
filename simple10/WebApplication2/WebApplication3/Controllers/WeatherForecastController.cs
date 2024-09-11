using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }
        
        //异常导致应用程序崩溃
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // 启动一个任务到线程池中
            ThreadPool.QueueUserWorkItem(DoWork);
            ThreadPool.QueueUserWorkItem(DoWork2);

            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(10000);

            return Enumerable.Empty<WeatherForecast>();
        }

        //线程异常，应用程序不会崩溃
        [HttpGet("get2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            throw new Exception("异常");
            return Enumerable.Empty<WeatherForecast>();
        }
        //线程异常，应用程序不会崩溃
        [HttpGet("get3")]
        public IEnumerable<WeatherForecast> Get3()
        {
            Task.Run(() => {
                throw new Exception("异常");
            });
            Thread.Sleep(1000);
            return Enumerable.Empty<WeatherForecast>();
        }
        //线程异常，应用程序不会崩溃
        [HttpGet("get4")]
        public async Task<IEnumerable<WeatherForecast>> Get4()
        {
            await Task.Run(() =>
            {
                throw new Exception("异常");
            });
             
            return Enumerable.Empty<WeatherForecast>();
        }

        //异常导致应用程序崩溃
        [HttpGet("get5")]
        public async Task<IEnumerable<WeatherForecast>> Get5()
        {
            Thread th = new Thread(new ThreadStart(() => {
                throw new Exception("线程异常");
            }));
            th.Start();
            th.Join();

            return Enumerable.Empty<WeatherForecast>();
        }


        static void DoWork(object state)
        {
            // 模拟一个可能抛出异常的操作
            throw new Exception("Oops, something went wrong!");
        }

        static void DoWork2(object state)
        {
            // 捕获并处理异常
            Console.WriteLine($"DoWork2");
        }
    }
}
