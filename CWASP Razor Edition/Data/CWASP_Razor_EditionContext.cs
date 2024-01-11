using Microsoft.EntityFrameworkCore;

namespace CWASP_Razor_Edition.Data
{
    public class CWASP_Razor_EditionContext(DbContextOptions<CWASP_Razor_EditionContext> options) : DbContext(options)
    {
        public DbSet<CWASP_Razor_Edition.Models.Ticket> Ticket { get; set; } = default!;
    }
}
