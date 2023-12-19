using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CWASP_Razor_Edition.Models;

namespace CWASP_Razor_Edition.Data
{
    public class CWASP_Razor_EditionContext : DbContext
    {
        public CWASP_Razor_EditionContext (DbContextOptions<CWASP_Razor_EditionContext> options)
            : base(options)
        {
        }

        public DbSet<CWASP_Razor_Edition.Models.Ticket> Ticket { get; set; } = default!;
    }
}
