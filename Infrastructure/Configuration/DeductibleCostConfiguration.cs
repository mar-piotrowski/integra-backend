using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DeductibleCostConfiguration : IEntityTypeConfiguration<DeductibleCost> {
    public void Configure(EntityTypeBuilder<DeductibleCost> builder) {
        builder.HasKey("Id");
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => DeductibleCostId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}