using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace WebApplication1
{
    public class CustomerAuthenticationHander : AuthenticationHandler<CustomerAuthenticationHanderOptions>
    {
        public CustomerAuthenticationHander(IOptionsMonitor<CustomerAuthenticationHanderOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var aa = Context.Request.Query["token"].ToString();
            if (aa.IsNullOrEmpty()) return AuthenticateResult.Fail("认证失败");
            var claimsIdentity = new ClaimsIdentity(new List<Claim>(){
                new Claim(ClaimTypes.Name,aa)
                }, Scheme.Name);
            var ident = new System.Security.Claims.ClaimsPrincipal(new List<ClaimsIdentity>() {
              claimsIdentity
            });

            var aaaa1 = claimsIdentity.AuthenticationType;
            var aaaa = claimsIdentity.IsAuthenticated;
            return AuthenticateResult.Success(new AuthenticationTicket(ident, Scheme.Name));
        }


    }
}
