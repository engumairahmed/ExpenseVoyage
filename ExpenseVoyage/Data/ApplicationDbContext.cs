using ExpenseVoyage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ExpenseVoyage.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProfile>()
              .HasOne(up => up.IdentityUser)
              .WithOne()
              .HasForeignKey<UserProfile>(up => up.IUserId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
