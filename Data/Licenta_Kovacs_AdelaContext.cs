using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Data
{
    public class Licenta_Kovacs_AdelaContext : DbContext
    {
        public Licenta_Kovacs_AdelaContext (DbContextOptions<Licenta_Kovacs_AdelaContext> options)
            : base(options)
        {
        }

        public DbSet<Licenta_Kovacs_Adela.Models.CafeaClient> CafeaClient { get; set; } = default!;

        public DbSet<Licenta_Kovacs_Adela.Models.Membru>? Membru { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.Aroma>? Aroma { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.Bob>? Bob { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.Lapte>? Lapte { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.Topping>? Topping { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.TipCafea>? TipCafea { get; set; }

        public DbSet<Licenta_Kovacs_Adela.Models.Marime>? Marime { get; set; }
    }
}
