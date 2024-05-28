using Microsoft.AspNetCore.Builder;

namespace WebApplication2
{
    public class DemoMiddware
    {
        private RequestDelegate _next;

        public DemoMiddware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("demo-1");
            Thread.Sleep(1000);
            try
            {

                await _next.Invoke(context);

            }
            catch (Exception ex)
            {
                throw;
            }
            Console.WriteLine("demo-2");
        }
    }
    public static class DemoMiddwareExtens
    {
        public static IApplicationBuilder UseDemo(this WebApplication builder)
        {
            return builder.UseMiddleware<DemoMiddware>();
        }
    }
}
