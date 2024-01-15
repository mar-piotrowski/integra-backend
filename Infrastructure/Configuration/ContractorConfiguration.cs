using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ContractorConfiguration : IEntityTypeConfiguration<Contractor> {
    public void Configure(EntityTypeBuilder<Contractor> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ContractorId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Nip)
            .HasConversion(c => c.Value, value => Nip.Create(value));
        builder.Property(p => p.Email)
            .HasConversion(c => c.Value, value => Email.Create(value));
        builder.Property(p => p.Phone)
            .HasConversion(c => c.Value, value => Phone.Create(value));
        builder.Property(p => p.BankAccountId)
            .HasConversion(c => c.Value, value => BankAccountId.Create(value));
    }
}