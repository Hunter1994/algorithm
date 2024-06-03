using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationDemo.Pages
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task OnPost()
        {
            await HttpContext.SignOutAsync();
            Redirect("/");
        }
    }
}
