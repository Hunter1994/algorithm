using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(ILogger<LoginModel> logger,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var a = _signInManager.GetExternalAuthenticationSchemesAsync().Result;
            _signInManager.SignInAsync(new IdentityUser()
            {
                UserName = "admin"
            }, true);
        }
    }

}
