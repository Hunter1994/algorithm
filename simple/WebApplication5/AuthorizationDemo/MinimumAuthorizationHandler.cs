using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthorizationDemo
{
    public class MinimumAuthorizationHandler : AuthorizationHandler<MinimumAuthorizationAttribute>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            MinimumAuthorizationAttribute requirement)
        {
            var dateOfBirth= context.User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.DateOfBirth);
            if (dateOfBirth != null)
            {
                var dob = Convert.ToDateTime(dateOfBirth.Value);
                var age=DateTime.Now.Year- dob.Year;
                if (dob < DateTime.Now.AddYears(-age))
                {
                    --age;
                }
                if (age >= requirement.Age) 
                    context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
