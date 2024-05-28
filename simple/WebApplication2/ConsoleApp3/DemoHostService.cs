using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class DemoHostService : IHostedService
    {
        private IHostLifetime _hostLifetime;
        private IHostEnvironment _hostEnvironment;
        private IConfiguration _configuration;
        private IOptionsMonitor<Person> _options;
        private IServiceProvider _serviceProvider;

        public DemoHostService(IHostLifetime hostLifetime, IHostEnvironment hostEnvironment,IConfiguration configuration,IOptionsMonitor<Person> options,IServiceProvider serviceProvider)
        {
            _hostLifetime = hostLifetime;
            _hostEnvironment = hostEnvironment;
            _configuration = configuration;
            _options = options;
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //Person p = new Person();
            // _configuration.GetSection("Person").Bind(p);

            while (true)
            {
                Console.ReadLine();
                Person p = _options.CurrentValue;
                Console.WriteLine("p:"+ p);
                using (var scope = _serviceProvider.CreateScope())
                {
                   var p2= scope.ServiceProvider.GetService<IOptionsSnapshot<Person>>().Value;
                    Console.WriteLine("p2:"+p2);
                }
            }


            Console.WriteLine($"a:{_configuration["a"]}");
            Console.WriteLine($"b:{_configuration["b"]}");
            Console.WriteLine("StartAsync");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("StopAsync");
        }
    }
}
