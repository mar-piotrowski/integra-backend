using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card> {
    public void Configure(EntityTypeBuilder<Card> builder) {
        builder.HasKey(a => a.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => CardId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.Number)
            .HasConversion(c => c.Value, value => CardNumber.Create(value));
    }
}