using System.Resources;

namespace WebApplication4
{
    public class ConventionalMiddleware
    {
        private readonly RequestDelegate _next;
        DateTime dateTime;

        public ConventionalMiddleware(RequestDelegate next)
        { 
            _next = next;
            dateTime = DateTime.Now;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var keyValue = context.Request.Query["key"];

            Console.WriteLine("1:"+dateTime);

            await _next(context);
        }
    }

    public class FactoryActivatedMiddleware : IMiddleware
    {
        DateTime dateTime;
        public FactoryActivatedMiddleware()
        {
            dateTime = DateTime.Now;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var keyValue = context.Request.Query["key"];
            Console.WriteLine("2:" + dateTime);
            await next(context);


        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(
            this IApplicationBuilder app)
            => app.UseMiddleware<ConventionalMiddleware>();

        public static IApplicationBuilder UseFactoryActivatedMiddleware(
            this IApplicationBuilder app)
            => app.UseMiddleware<FactoryActivatedMiddleware>();
    }



}
