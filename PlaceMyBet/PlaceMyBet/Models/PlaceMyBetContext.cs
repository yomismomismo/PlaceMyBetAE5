using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class PlaceMyBetContext : DbContext
    {

        public DbSet<Evento> Eventos { get; set; } 
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=placemybet;Uid=root;Password=;SslMode=none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().HasData(new Usuario("tumismo@yomismo.cat", "Tumismo'", "mismo", 19));
            modelBuilder.Entity<Usuario>().HasData(new Usuario("yomismomismo@yomismo.cat", "Yomismo", "Mismo", 21));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(4, "Bankmismo", 452147943, 200, "yomismomismo@yomismo.cat"));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 1.74, 2.09, 240, 200, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2.5, 1.9, 1.9, 210, 100, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(3, 3.5, 2.85, 1.43, 50, 100, 1));
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Espanyol", "2020-09-16", 0));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 10, "Over", 1.9, "2020-11-04 11:37:06", 1, "yomismomismo@yomismo.cat"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(5, 10, "Over", 1.78, "2020-11-04 11:38:12", 1, "tumismo@yomismo.cat"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(6, 10, "Over", 1.9, "2020-11-04 12:10:35", 2, "tumismo@yomismo.cat"));

        }

    }
}