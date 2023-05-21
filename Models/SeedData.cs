using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infeco.Data;
using System;
using System.Linq;

namespace Infeco.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InfecoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<InfecoContext>>()))
            {
                // Look for any movies.
                if (context.Client.Any())
                {
                    return;   // DB has been seeded
                }

                context.Client.AddRange(
                    new Client
                    {
                        Nom = "Dupont",
                        Prenom = "Henri",
                        NumeroTel = "01 02 03 04 05",
                        Mail = "dupont.henri@yahoo.fr"
                    },

                    new Client
                    {
                        Nom = "Martin",
                        Prenom = "Jean",
                        NumeroTel = "06 07 08 09 10",
                        Mail = ""
                    },

                    new Client
                    {
                        Nom = "Durand",
                        Prenom = "Pierre",
                        NumeroTel = "11 12 13 14 15",
                        Mail = ""
                    }
            );

                context.Appartement.AddRange(
                    new Appartement
                    {
                        Id = 1,
                        Nom = "Appartement 1",
                        Adresse = "1 rue de la Paix"
                    },
                    new Appartement
                    {
                        Id = 2,
                        Nom = "Appartement 2",
                        Adresse = "10 rue de la Paix"
                    }
                );

                context.Location.AddRange(
                    new Location
                    {
                        Nom = "Location 1",
                        IdClient = 1,
                        Client = null,
                        IdAppartement = 1,
                        MontantLoyer = 520,
                        MontantDepotGarantie = 200
                    },
                    new Location
                    {
                        Nom = "Location 2",
                        IdClient = 3,
                        Client = null,
                        IdAppartement = 1,
                        MontantLoyer = 520,
                        MontantDepotGarantie = 200
                    },
                    new Location
                    {
                        Nom = "Location 3",
                        IdClient = 2,
                        Client = null,
                        IdAppartement = 2,
                        MontantLoyer = 520,
                        MontantDepotGarantie = 200
                    },
                    new Location
                    {
                        Nom = "Location 4",
                        IdClient = null,
                        Client = null,
                        IdAppartement = 2,
                        MontantLoyer = 520,
                        MontantDepotGarantie = 200
                    },
                    new Location
                    {
                        Nom = "Location 5",
                        IdClient = null,
                        Client = null,
                        IdAppartement = 2,
                        MontantLoyer = 520,
                        MontantDepotGarantie = 200
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
