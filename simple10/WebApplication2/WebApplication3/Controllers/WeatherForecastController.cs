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
        
        //�쳣����Ӧ�ó������
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            // ����һ�������̳߳���
            ThreadPool.QueueUserWorkItem(DoWork);
            ThreadPool.QueueUserWorkItem(DoWork2);

            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(10000);

            return Enumerable.Empty<WeatherForecast>();
        }

        //�߳��쳣��Ӧ�ó��򲻻����
        [HttpGet("get2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            throw new Exception("�쳣");
            return Enumerable.Empty<WeatherForecast>();
        }
        //�߳��쳣��Ӧ�ó��򲻻����
        [HttpGet("get3")]
        public IEnumerable<WeatherForecast> Get3()
        {
            Task.Run(() => {
                throw new Exception("�쳣");
            });
            Thread.Sleep(1000);
            return Enumerable.Empty<WeatherForecast>();
        }
        //�߳��쳣��Ӧ�ó��򲻻����
        [HttpGet("get4")]
        public async Task<IEnumerable<WeatherForecast>> Get4()
        {
            await Task.Run(() =>
            {
                throw new Exception("�쳣");
            });
             
            return Enumerable.Empty<WeatherForecast>();
        }

        //�쳣����Ӧ�ó������
        [HttpGet("get5")]
        public async Task<IEnumerable<WeatherForecast>> Get5()
        {
            Thread th = new Thread(new ThreadStart(() => {
                throw new Exception("�߳��쳣");
            }));
            th.Start();
            th.Join();

            return Enumerable.Empty<WeatherForecast>();
        }


        static void DoWork(object state)
        {
            // ģ��һ�������׳��쳣�Ĳ���
            throw new Exception("Oops, something went wrong!");
        }

        static void DoWork2(object state)
        {
            // ���񲢴����쳣
            Console.WriteLine($"DoWork2");
        }
    }
}
