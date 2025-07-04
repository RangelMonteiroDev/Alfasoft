using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManager.Pages.Contacts
{
    public class LogoutModel : PageModel
    {
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            // Usa o mesmo nome de esquema definido no Program.cs
            await HttpContext.SignOutAsync("Cookies");

            // Redireciona para a lista pública
            return RedirectToPage("/Contacts/Index");
        }
    }
}

