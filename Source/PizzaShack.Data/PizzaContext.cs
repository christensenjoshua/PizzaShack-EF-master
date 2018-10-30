using Microsoft.EntityFrameworkCore;
using PizzaShack.Entities;
using System;

namespace PizzaShack.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Side> Sides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=PizzaShack;
                Integrated Security=True");
        }


    }
}
