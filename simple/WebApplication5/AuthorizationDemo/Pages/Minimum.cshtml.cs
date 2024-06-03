using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationDemo.Pages
{
    [Authorize(Policy = "MinimumAge1")]
    public class MinimumModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
