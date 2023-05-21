using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infeco.Models;

namespace Infeco.Data
{
    public class InfecoContext : DbContext
    {
        public InfecoContext (DbContextOptions<InfecoContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Appartement> Appartement { get; set; }
        public DbSet<Facture> Facture { get; set; }

    }
}
