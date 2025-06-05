using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental_Strikes_Back.Model;

namespace Rental_Strikes_Back
{
    internal interface IContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<FilmActor> FilmActors { get; set; }

        public DbSet<FilmCategory> FilmCategories { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
