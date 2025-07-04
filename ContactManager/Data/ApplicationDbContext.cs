using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);          // 1

        modelBuilder.Entity<Contact>(e =>
        {
            e.HasKey(c => c.ID);                     // 4

            // unicidade
            e.HasIndex(c => c.Email).IsUnique();
            e.HasIndex(c => c.ContactNumber).IsUnique();

            // filtro global para soft‑delete
            e.HasQueryFilter(c => !c.IsDeleted);     // 2

            // tamanhos & default
            e.Property(c => c.Name).HasMaxLength(120);          // 3
            e.Property(c => c.ContactNumber).HasMaxLength(9);   // 3
            e.Property(c => c.Email).HasMaxLength(160);         // 3
            e.Property(c => c.IsDeleted).HasDefaultValue(false);// 6
        });
    }
    }
}