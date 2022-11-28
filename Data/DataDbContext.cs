using D_Einder_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace D_Einder_MVC.Data
{
    public class DataDbContext : IdentityDbContext
    {
        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Ingredienten> Ingredienten { get; set; }



        public DbSet<Tafel> Tafel { get; set; }

        public DbSet<Financie> Financie { get; set; }

        public DbSet<GerechtenIngredienten> GerechtenIngredienten { get; set; }

        public DbSet<Gerechten> Gerechten { get; set; }

        public DbSet<MenuGerechten> MenuGerechten { get; set; }

        public DbSet<MenuSoort> MenuSoort { get; set; }


        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BETA-V1;Trusted_Connection=True;MultipleActiveResultSets=true");

        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Order>().HasKey(sc => new { sc.ReserveringenId, sc.MenuNaam });
            modelbuilder.Entity<DrinkBestellingen>().HasKey(sc => new { sc.TafelId, sc.DrinkId });
            modelbuilder.Entity<Menu>()
            .HasOne<MenuSoort>(s => s.MenuSoort)
            .WithMany(g => g.Menus)
            .HasForeignKey(s => s.MenuSoortId);
            modelbuilder.Entity<MenuGerechten>().HasKey(sc => new { sc.MenuId, sc.GerechtenId });
            modelbuilder.Entity<GerechtenIngredienten>().HasKey(sc => new { sc.GerechtenId, sc.IngredientenId });
            base.OnModelCreating(modelbuilder);
        }


        public DbSet<DrinkBestellingen> DrinkBestelling { get; set; }

        public DbSet<Reserveringen> Reserveringen { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<User> ApplicationUser { get; set; }


    }
}
