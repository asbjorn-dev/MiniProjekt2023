using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TrådeContext : DbContext
    {
        public DbSet<Tråde> Trådes => Set<Tråde>();
        public DbSet<Kommentar> Kommentar => Set<Kommentar>();



        public TrådeContext(DbContextOptions<TrådeContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}
