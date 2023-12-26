using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CWASP_Razor_Edition.Data;
using CWASP_Razor_Edition.Models;

namespace CWASP_Razor_Edition.Pages
{
    public class CreateModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context) : PageModel
    {
        [ViewData]
        public string? Message { get; set; }

        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context = context;

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostSubmit()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
                if (t.StudentName == Ticket.StudentName || t.LoanerOTO == Ticket.LoanerOTO)                 // if there is a match, return the partial view with the message
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
