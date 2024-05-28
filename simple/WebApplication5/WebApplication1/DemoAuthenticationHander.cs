using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace WebApplication1
{
    public class DemoAuthenticationHander : OAuthHandler<OAuthOptions>
    {
        public DemoAuthenticationHander(IOptionsMonitor<OAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>(){
                new Claim(ClaimTypes.Name,"aa")
                }, Scheme.Name);
            var ident = new System.Security.Claims.ClaimsPrincipal(new List<ClaimsIdentity>() {
              claimsIdentity
            });

            var aaaa1 = claimsIdentity.AuthenticationType;
            var aaaa = claimsIdentity.IsAuthenticated;
            return new AuthenticationTicket(ident, Scheme.Name);
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return base.HandleAuthenticateAsync();
        }
    }
}
