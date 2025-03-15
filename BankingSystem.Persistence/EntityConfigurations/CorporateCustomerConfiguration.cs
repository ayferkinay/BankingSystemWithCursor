using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Persistence.EntityConfigurations
{
    public class CorporateCustomerConfiguration : IEntityTypeConfiguration<CorporateCustomer>
    {
        public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            builder.ToTable("CorporateCustomers");

            builder.Property(c => c.CompanyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.TaxNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.TaxOffice)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CompanyType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.CommercialRegistrationNumber)
                .HasMaxLength(50);

            builder.Property(c => c.AnnualRevenue)
                .HasPrecision(18, 2);

            builder.Property(c => c.AuthorizedPersonName)
                .HasMaxLength(100);

            builder.Property(c => c.AuthorizedPersonPosition)
                .HasMaxLength(100);

            builder.Property(c => c.SectorOfActivity)
                .HasMaxLength(100);
        }
    }
} 