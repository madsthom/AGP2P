using System;
using System.Collections.Generic;
using System.Text;
using AGP2P.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AGP2P.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many relationship between BusinessProfile and Parts 
            modelBuilder.Entity<BusinessProfile>()
                .HasMany<Part>(s => s.Parts)
                .WithOne(g => g.BusinessProfile)
                .HasForeignKey(s => s.BusinessProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many relationship between BusinessProfile and ApplicationUser 
            modelBuilder.Entity<BusinessProfile>()
                .HasMany<ApplicationUser>(au => au.ApplicationUsers)
                .WithOne(bp => bp.BusinessProfile)
                .HasForeignKey(s => s.BusinessProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Part>()
                .HasKey(p => p.PartId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Part> Parts { get; set; }
        public DbSet<BusinessProfile> BusinessProfiles { get; set; }

    }
}
