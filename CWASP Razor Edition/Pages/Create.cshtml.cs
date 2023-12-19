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
    public class CreateModel : PageModel
    {
        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context;

        public CreateModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
