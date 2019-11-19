using System;
using FinanzasBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.Data
{
    public class FinanzasContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pyme> Pymes { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<DiscountPool> DiscountPools { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<Record> Records { get; set; }
        // public DbSet<DiscountCost> DiscountCosts { get; set; }
        
        public FinanzasContext(DbContextOptions<FinanzasContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Pyme>();
            modelBuilder.Entity<Bill>();
            modelBuilder.Entity<Bank>();
            modelBuilder.Entity<DiscountPool>();
            modelBuilder.Entity<Discount>();
            modelBuilder.Entity<Cost>();
            modelBuilder.Entity<Record>();
        }
    }
}