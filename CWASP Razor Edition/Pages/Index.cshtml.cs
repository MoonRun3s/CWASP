using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CWASP_Razor_Edition.Data;
using CWASP_Razor_Edition.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CWASP_Razor_Edition.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context;

        public IndexModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchOTO { get; set; }

        public SelectList? Reason { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TicketReason { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> reasonQuery = from m in _context.Ticket
                                            orderby m.Reason
                                            select m.Reason;

            var tickets = from m in _context.Ticket
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                tickets = tickets.Where(s => s.StudentName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SearchOTO))
            {
                tickets = tickets.Where(o => o.LoanerOTO.Contains(SearchOTO));
            }

            if (!string.IsNullOrEmpty(TicketReason))
            {
                tickets = tickets.Where(x => x.Reason == TicketReason);
            }

            Reason = new SelectList(await reasonQuery.Distinct().ToListAsync());
            Ticket = await tickets.ToListAsync();
        }
    }
}
