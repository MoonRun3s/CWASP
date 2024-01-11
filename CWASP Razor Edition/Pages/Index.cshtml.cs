using CWASP_Razor_Edition.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CWASP_Razor_Edition.Pages
{
    public class IndexModel(CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext context) : PageModel
    {
        private readonly CWASP_Razor_Edition.Data.CWASP_Razor_EditionContext _context = context;
        public IList<Ticket> Ticket { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchOTO { get; set; }

        public SelectList? Reason { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TicketReason { get; set; }

        public IQueryable<Ticket> PopulateModelVariable()
        {
            var tickets = from m in _context.Ticket
                          select m;
            return tickets;
        }

        public IQueryable<Ticket> PrepareModel(IQueryable<Ticket> tickets)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
                tickets = tickets.Where(x => x.Reason.Equals(TicketReason));
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return tickets;
        }

        public async Task OnGetAsync()
        {
            var tickets = PopulateModelVariable();

            // Use LINQ to get list of genres.
            IQueryable<string> reasonQuery = from m in _context.Ticket
                                             orderby m.Reason
                                             select m.Reason;

            tickets = PrepareModel(tickets);

            Reason = new SelectList(await reasonQuery.Distinct().ToListAsync());
            Ticket = await tickets.ToListAsync();
        }

        public async Task<PartialViewResult?> OnGetDataListPartial()
        {
            var tickets = PopulateModelVariable();

            // Use LINQ to get list of genres.
            IQueryable<string> reasonQuery = from m in _context.Ticket
                                             orderby m.Reason
                                             select m.Reason;

            tickets = PrepareModel(tickets);

            Reason = new SelectList(await reasonQuery.Distinct().ToListAsync());
            Ticket = await tickets.ToListAsync();

            if ((string.IsNullOrEmpty(SearchOTO)) && (string.IsNullOrEmpty(SearchOTO)) && (string.IsNullOrEmpty(TicketReason)))
            {
                return Partial("_DataList", Ticket);
            }

            return null;
        }
    }
}
