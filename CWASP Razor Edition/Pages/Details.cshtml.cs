using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CWASP_Razor_Edition.Data;
using CWASP_Razor_Edition.Models;

namespace CWASP_Razor_Edition.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context;

        public DetailsModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                Ticket = ticket;
            }
            return Page();
        }
    }
}
