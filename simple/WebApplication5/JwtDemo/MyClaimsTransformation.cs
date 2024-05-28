using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace JwtDemo
{
    public class MyClaimsTransformation : IClaimsTransformation
    {
        public  Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
           
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "myClaimValue"));

            principal.AddIdentity(claimsIdentity);
            return Task.FromResult(principal);
        }
    }
}
