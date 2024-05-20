using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class BackendContext : DbContext
    {
        public BackendContext (DbContextOptions<BackendContext> options)
            : base(options)
        {
        }
        public DbSet<Backend.Models.Kategoria> Kategoria { get; set; } = default!;

        public DbSet<Backend.Models.Ingatlan>? Ingatlan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Server=(localdb)\\mssqllocaldb;Database=Backend.Data;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>().HasIndex(k => k.Nev).IsUnique();

            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria() { Id = 1, Nev = "Ház" },
                new Kategoria() { Id = 2, Nev = "Lakás" },
                new Kategoria() { Id = 3, Nev = "Építési telek" },
                new Kategoria() { Id = 4, Nev = "Garázs" },
                new Kategoria() { Id = 5, Nev = "Mezőgazdasági terület" },
                new Kategoria() { Id = 6, Nev = "Ipari ingatlan" }
            );
        }
    }
}
