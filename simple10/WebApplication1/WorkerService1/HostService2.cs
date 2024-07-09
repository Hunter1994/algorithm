using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class HostService2 : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HostService2");

        }

        public Task StopAsync(CancellationToken cancellationToken)=>Task.CompletedTask;
        
    }
}
