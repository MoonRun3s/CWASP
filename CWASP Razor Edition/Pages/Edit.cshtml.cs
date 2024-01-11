using CWASP_Razor_Edition.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CWASP_Razor_Edition.Pages
{
    public class EditModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context) : PageModel
    {
        [ViewData]
        public string? Message { get; set; }

        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context = context;

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Error");
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                // return NotFound();
                return RedirectToPage("./Error");
            }
            Ticket = ticket;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.Id))
                {
                    // return NotFound();
                    return RedirectToPage("./Error");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }

        public IActionResult OnPostCheckDuplicates()
        {

            if (!ModelState.IsValid)
            {
                Message = "CAUTION: Ticket does not have required fields.";
                return Page();
            }

            var tickets = from t in _context.Ticket                                                         // get all tickets from database
                          select t;

            foreach (var t in tickets)                                                                      // compare new ticket "student name" and "loaneroto" values to all tickets in db
            {
                if ((t.StudentName == Ticket.StudentName || t.LoanerOTO == Ticket.LoanerOTO) && (t.Id != Ticket.Id))                 // if there is a match, return the partial view with the message (ignoring self)
                {
                    Message = "CAUTION: Ticket OTO # or student Name already exists in database.";
                    return Page();
                };
            }

            Message = "No duplicates found.";
            return Page();
        }
    }
}
