﻿using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace WebApplication1
{
    public class RedisRateLimiterPolicy : IRateLimiterPolicy<string>
    {
        public Func<OnRejectedContext, CancellationToken, ValueTask>? OnRejected => throw new NotImplementedException();

        public RateLimitPartition<string> GetPartition(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }
    }
}
