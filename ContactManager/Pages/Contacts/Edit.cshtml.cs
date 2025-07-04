using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _context.Contacts.FindAsync(id);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var contactToUpdate = await _context.Contacts.FindAsync(Contact.ID);

            if (contactToUpdate == null)
            {
                return NotFound();
            }

            // Atualiza os campos
            contactToUpdate.Name = Contact.Name;
            contactToUpdate.ContactNumber = Contact.ContactNumber;
            contactToUpdate.Email = Contact.Email;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Erro ao salvar dados. Verifique os dados e tente novamente.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}

