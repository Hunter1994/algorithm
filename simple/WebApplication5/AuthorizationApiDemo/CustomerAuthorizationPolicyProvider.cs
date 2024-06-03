using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace AuthorizationApiDemo
{
    public class CustomerAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider DefaultAuthorizationPolicyProvider;
        public CustomerAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) {
            DefaultAuthorizationPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            var a = DefaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();
            return a;
        }

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        { 
        var b= DefaultAuthorizationPolicyProvider.GetFallbackPolicyAsync();
            return b;
        }

        public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith("G"))
            {
                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new CustomerAuthorizationRequirment(policyName));
                return policy.Build();
            }
            else
            {
                return null;
            }
            
        }
    }
}
