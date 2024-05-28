using Microsoft.AspNetCore.RateLimiting;
using StackExchange.Redis;
using System.Net;
using System.Threading.RateLimiting;

namespace WebApplication3
{
    public class RedisRateLimiterPolicy : IRateLimiterPolicy<string>
    {
        private IConnectionMultiplexer _redisConnection;

        public RedisRateLimiterPolicy(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }
        public Func<OnRejectedContext, CancellationToken, ValueTask>? OnRejected => async (ctx, token) =>
        {
            ctx.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            await ctx.HttpContext.Response.WriteAsync("操作频繁！");
        };

        public RateLimitPartition<string> GetPartition(HttpContext httpContext)
        {
            var name= httpContext.User.Identity.Name;
            var redisDatabase = _redisConnection.GetDatabase();
            var counter = redisDatabase.StringIncrement(name);
            if (counter == 1)
            {
                redisDatabase.KeyExpire(name, DateTime.Now.AddSeconds(60));
            }
            if (counter >1)
            {
                // Return a limiter indicating that the request is rejected
                return RateLimitPartition.GetNoLimiter(name)!;
            }

            // Return a limiter allowing the request
            var limiter = RateLimitPartition.GetSlidingWindowLimiter(name,
                _ => new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = 1,
                    Window = TimeSpan.FromSeconds(60),
                    SegmentsPerWindow = 1
                })!;
            return limiter;
        }
    }
}
