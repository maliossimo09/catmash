using System;
using System.Reflection;
using catmash.Models;
using Microsoft.EntityFrameworkCore;

namespace catmash.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cat> Cat { get; set; }

        public AppDbContext() {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Cat>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
