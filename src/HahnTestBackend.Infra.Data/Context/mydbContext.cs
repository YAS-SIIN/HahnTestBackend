using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HahnTestBackend.Domain.Entities;

namespace HahnTestBackend.Infra.Data.Context
{
    public class myDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }              

        public myDBContext(DbContextOptions options) 
            : base(options)
        {
        }

        public myDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>().Property(a => a.SureName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Employee>().Property(a => a.NationalCode)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(myDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("DefaultConnection");
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                    continue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                    entry.Property("Updated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}