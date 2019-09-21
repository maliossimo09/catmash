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
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Ce constructeur sera utilisé pour les tests
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

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
