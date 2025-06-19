using Microsoft.EntityFrameworkCore;
using Leads.Domain.Entities;
using Leads.Infra.Configurations;

namespace Leads.Infra.Context
{
    public class LeadDbContext : DbContext
    {
        public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Property> Properties { get; set; }
        public DbSet<InteractionBot> Interactions { get; set; } = null!;
        public DbSet<LeadsInterest> LeadsInterests { get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LeadConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new InteractionBotConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticsConfiguration());
            modelBuilder.ApplyConfiguration(new LeadsInterestConfiguration());
        }

    }
}
