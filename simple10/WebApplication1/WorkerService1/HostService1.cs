using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class HostService1 : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine("HostService1");
            await Task.Delay(1000);
        }

        public Task StopAsync(CancellationToken cancellationToken)=>Task.CompletedTask;
        
    }
}
