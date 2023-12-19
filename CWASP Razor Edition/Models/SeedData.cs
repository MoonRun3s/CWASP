using Microsoft.EntityFrameworkCore;
using CWASP_Razor_Edition.Data;

namespace CWASP_Razor_Edition.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CWASP_Razor_EditionContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<CWASP_Razor_EditionContext>>()))
            {
                if (context == null || context.Ticket == null)
                {
                    throw new ArgumentNullException("Null CWASP_Razor_EditionContext");
                }

                // Look for any tivkets.
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
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
