using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthorizationApiDemo.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<string> LoginAsync()
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, "456@qq.com"), new Claim(ClaimTypes.Role, "admin") };
            ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDI2a2EJ7m872v0afyoSDJT2o1+SitIeJSWtLJU8/Wz2m7gStexajkeD+Lka6DSTy8gt9UwfgVQo6uKjVLG5Ex7PiGOODVqAEghBuS7JzIYU5RvI543nNDAPfnJsas96mSA7L/mD7RTE2drj6hf3oZjJpMPZUQI/B1Qjb5H3K3PNwIDAQAB"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "https://localhost:7281",
                audience: "Ousu_Xld_Platform",
                claims: claims,
                expires: DateTime.Now.AddDays(300),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("LoginCookie")]
        public async Task LoginCookieAsync()
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, "456@qq.com"), new Claim(ClaimTypes.Role, "admin") };
            ClaimsIdentity identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

    }
}
