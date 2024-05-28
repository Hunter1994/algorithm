using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DemoMiddeware1
    {
        private RequestDelegate _next;

        public DemoMiddeware1(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("DemoMiddeware1-1");
            await _next.Invoke(context);
            Console.WriteLine("DemoMiddeware1-2");
        }
    }
}
