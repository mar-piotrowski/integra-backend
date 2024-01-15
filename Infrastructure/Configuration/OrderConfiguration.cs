using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order> {
    public void Configure(EntityTypeBuilder<Order> builder) {
        builder.HasKey(o => o.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => OrderId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.ContractorId).HasConversion(c => c.Value, value => ContractorId.Create(value));
        builder.HasMany(a => a.Articles);
    }
}