using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AuthorizationDemo.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {

        public void OnGet()
        {
        }
        public async Task OnPost() {

            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, "456@qq.com"), new Claim(ClaimTypes.DateOfBirth, "2020-01-01") };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
        }
    }
}
