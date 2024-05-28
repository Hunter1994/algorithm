using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DemoMiddeware
    {
        private RequestDelegate _next;

        public DemoMiddeware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("DemoMiddeware1");
            await _next.Invoke(context);
            Console.WriteLine("DemoMiddeware2");

        }
    }
}
