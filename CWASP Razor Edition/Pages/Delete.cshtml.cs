using CWASP_Razor_Edition.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CWASP_Razor_Edition.Pages
{
    public class DeleteModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context) : PageModel
    {
        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context = context;

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                // return NotFound();
                return RedirectToPage("./Error");
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null)
            {
                // return NotFound();
                return RedirectToPage("./Error");
            }
            else
            {
                Ticket = ticket;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Error");
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                Ticket = ticket;
                _context.Ticket.Remove(Ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
