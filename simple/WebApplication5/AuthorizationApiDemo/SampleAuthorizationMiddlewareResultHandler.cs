using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace AuthorizationApiDemo
{
    public class SampleAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {

        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

        public async Task HandleAsync(RequestDelegate next,
            HttpContext context, 
            AuthorizationPolicy policy, 
            PolicyAuthorizationResult authorizeResult)
        {
            // 如果授权被禁止并且资源有特定要求，则提供自定义404响应。
            if (authorizeResult.Forbidden
                && authorizeResult.AuthorizationFailure!.FailedRequirements
                    .OfType<CustomerAuthorizationRequirment>().Any())
            {
                // 返回一个404，使其看起来好像资源不存在。
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }

            // 回退到默认实现。
            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
