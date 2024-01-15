using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ContractChangeConfiguration : IEntityTypeConfiguration<ContractChange> {
    public void Configure(EntityTypeBuilder<ContractChange> builder) {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ContractChangeId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.ContractId)
            .HasConversion(c => c.Value, value => ContractId.Create(value));
        builder.Property(p => p.ContractChangeId)
            .HasConversion(c => c.Value, value => ContractId.Create(value));
        builder.HasOne(c => c.Contract)
            .WithMany(c => c.ContractBase)
            .HasForeignKey(k => k.ContractId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.ContractChanged)
            .WithMany(c => c.ContractChanges)
            .HasForeignKey(k => k.ContractChangeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}