using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication9
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public  ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return ValueTask.FromResult(false);
        }
    }
}
