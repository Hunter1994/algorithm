using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AuthorizationApiDemo
{
    public class CustomerAuthorizationHandler : AuthorizationHandler<CustomerAuthorizationRequirment>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CustomerAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            CustomerAuthorizationRequirment requirement)
        {
            if (context.User.Identity.Name != null)
            {
                if (UserPermisstion.Users[context.User.Identity.Name].Contains(requirement.Name))
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
