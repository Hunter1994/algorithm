using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebApplication2
{
    public class CustomCookieAuthenticationEvents:CookieAuthenticationEvents
    {

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var claims= context.Principal.Claims.Where(r => r.Type == ClaimTypes.Name).FirstOrDefault();
            if (!Redis.Tokens.Contains(claims.Value))//模拟redis 登录token不存在了
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

        }
    }
}
