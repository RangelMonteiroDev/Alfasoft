using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ContactManager.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _config;

        public LoginModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _config.GetSection("Authentication").Get<ContactManager.Models.UserCredentials>();

            if (Username == user?.Username && Password == user?.Password)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, Username)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToPage("/Contacts/Index");
            }

            ErrorMessage = "Invalid username or password.";
            return Page();
        }
    }
}

