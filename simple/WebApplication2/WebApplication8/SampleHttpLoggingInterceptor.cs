using Microsoft.AspNetCore.HttpLogging;

namespace WebApplication8
{
    public class SampleHttpLoggingInterceptor : IHttpLoggingInterceptor
    {
        public async ValueTask OnRequestAsync(HttpLoggingInterceptorContext logContext)
        {
        }

        public async ValueTask OnResponseAsync(HttpLoggingInterceptorContext logContext)
        {
            logContext.AddParameter("a", "a");
        }
    }
}
