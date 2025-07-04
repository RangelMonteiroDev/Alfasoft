using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages.Contacts;

[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _ctx;
    public IndexModel(ApplicationDbContext ctx) => _ctx = ctx;

    public IList<Contact> Contacts { get; private set; } = [];

    public async Task OnGetAsync()
    {
        // IsDeleted já é filtrado pelo HasQueryFilter
        Contacts = await _ctx.Contacts.AsNoTracking().ToListAsync();
    }
}
