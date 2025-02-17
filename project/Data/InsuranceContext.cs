using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        public DbSet<Insuree> Insurees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insuree>()
                .Property(i => i.Quote)
                .HasColumnType("decimal(18,2)");
        }
    }
} 