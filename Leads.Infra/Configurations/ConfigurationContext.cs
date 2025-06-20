using Leads.Domain.Entities;
using Leads.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leads.Infra.Configurations
{
    // =========================
    // User
    // =========================
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameUser).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.PasswordUser).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Actived).IsRequired();
        }
    }

    // =========================
    // Lead
    // =========================
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameLead).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneLead).IsRequired().HasMaxLength(20);
            builder.Property(x => x.InterestLead).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Neighborhood).HasMaxLength(80);
            builder.Property(x => x.City).HasMaxLength(80);
            builder.Property(x => x.TypeProperty).HasMaxLength(50);
            builder.Property(x => x.PriceMax);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Origin).HasMaxLength(50);
        }
    }

    // =========================
    // Property
    // =========================
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.TitleProperty).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Neighborhood).HasMaxLength(80);
            builder.Property(x => x.City).HasMaxLength(80);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Available).IsRequired();
            builder.Property(x => x.TypeAd).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Properties)
                   .HasForeignKey(x => x.UserId);
        }
    }

    // =========================
    // InteractionBot
    // =========================
    public class InteractionBotConfiguration : IEntityTypeConfiguration<InteractionBot>
    {
        public void Configure(EntityTypeBuilder<InteractionBot> builder)
        {
            builder.ToTable("InteractionBot");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.Direction).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.Sended).IsRequired();

            builder.HasOne(x => x.Lead)
                   .WithMany(x => x.Interactions)
                   .HasForeignKey(x => x.LeadId);
        }
    }

    // =========================
    // Statistics
    // =========================
    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.ToTable("Statistics");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Neighborhood).HasMaxLength(80);
            builder.Property(x => x.City).HasMaxLength(80);
            builder.Property(x => x.TypeProperty).HasMaxLength(50);
            builder.Property(x => x.InterestLead).HasMaxLength(20);
            builder.Property(x => x.CountPeople);
            builder.Property(x => x.LastSearch);
        }
    }

    // =========================
    // Leads_Interest
    // =========================
    public class LeadsInterestConfiguration : IEntityTypeConfiguration<LeadsInterest>
    {
        public void Configure(EntityTypeBuilder<LeadsInterest> builder)
        {
            builder.ToTable("Leads_Interest");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.OfferPrice);
            builder.Property(x => x.Status)
                   .HasDefaultValue(StatusInterest.Disponivel)
                   .IsRequired(false);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.UpdateAt);

            builder.HasOne(x => x.Lead)
                   .WithMany(x => x.Interests)
                   .HasForeignKey(x => x.LeadId);

            builder.HasOne(x => x.Property)
                   .WithMany(x => x.Interests)
                   .HasForeignKey(x => x.PropertyId);
        }
    }
}
