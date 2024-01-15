using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class StockConfiguration : IEntityTypeConfiguration<Stock> {
    public void Configure(EntityTypeBuilder<Stock> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => StockId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasMany(a => a.Articles);
    }
}