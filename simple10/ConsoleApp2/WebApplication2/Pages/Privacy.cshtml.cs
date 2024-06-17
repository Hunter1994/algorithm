using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApplication2.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public async void OnPost() {
            await HttpContext.SignInAsync(new ClaimsPrincipal(new List<ClaimsIdentity>() { new ClaimsIdentity (new List<Claim>() {
           new Claim(ClaimTypes.Name,"111@qq.com")
           },CookieAuthenticationDefaults.AuthenticationScheme) }));
        }
    }

}
