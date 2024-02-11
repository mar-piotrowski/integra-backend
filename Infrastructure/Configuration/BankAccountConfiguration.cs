using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount> {
    public void Configure(EntityTypeBuilder<BankAccount> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => BankAccountId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}