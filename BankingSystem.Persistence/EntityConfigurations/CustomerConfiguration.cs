using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.CustomerNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.TotalAssets)
                .HasPrecision(18, 2);

            builder.Property(c => c.TotalLiabilities)
                .HasPrecision(18, 2);

            builder.Property(c => c.Notes)
                .HasMaxLength(500);

            // TPT Configuration
            builder.UseTptMappingStrategy();
        }
    }
} 