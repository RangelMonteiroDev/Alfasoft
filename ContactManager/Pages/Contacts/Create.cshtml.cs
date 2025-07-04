using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
namespace ContactManager.Pages.Contacts;


[Authorize]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public Contact Contact { get; set; } = new();

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet() {}

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Contacts.Add(Contact);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
