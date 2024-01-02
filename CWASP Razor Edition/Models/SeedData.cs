using Microsoft.EntityFrameworkCore;
using CWASP_Razor_Edition.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CWASP_Razor_Edition.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new CWASP_Razor_EditionContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<CWASP_Razor_EditionContext>>());
            if (context == null || context.Ticket == null)
            {
                throw new ArgumentNullException("Null CWASP_Razor_EditionContext");
            }

            // Look for any tickets.
            if (context.Ticket.Any())
            {
                return;   // Don't continue: DB has been seeded
            }

            context.Ticket.AddRange(
                new Ticket
                {
                    LoanerOTO = "OTO00513",
                    StudentName = "John Smith",
                    Reason = "Other",
                    Description = "Description",
                }
            );
            context.SaveChanges();
        }
    }
}