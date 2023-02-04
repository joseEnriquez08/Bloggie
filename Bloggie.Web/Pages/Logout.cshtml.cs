using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInMaanager;

        public LogoutModel(SignInManager<IdentityUser> signInMaanager)
        {
            this.signInMaanager = signInMaanager;
        }

        public async Task<IActionResult> OnGet()
        {
            await signInMaanager.SignOutAsync();
            return RedirectToPage("Index");
        }
    }
}
