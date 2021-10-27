using Cupcakes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Data
{
    public class CupcakeContext : DbContext
    {
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }

        public CupcakeContext(DbContextOptions<CupcakeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bakery>().HasData(
                new Bakery
                {
                    BakeryId = 1,
                    BakeryName = "Gluteus Free",
                    Address = "635 Brighton Circle Road"
                });

            modelBuilder.Entity<Cupcake>().HasData(
                new Cupcake
                {
                    CupcakeId = 1,
                    CupcakeType = CupcakeType.Birthday,
                    Description = "Vanilla cupcake with coconut cream",
                    GlutenFree = true,
                    Price = 2.5,
                    BakeryId = 1,
                    ImageMimeType = "image/jpeg",
                    ImageName = "birthday-cupcake.jpg",
                    CaloricValue = 355
                });
        }
    }
}
