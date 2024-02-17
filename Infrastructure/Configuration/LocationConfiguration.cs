using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location> {
    public void Configure(EntityTypeBuilder<Location> builder) {
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => LocationId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.ContractorId)
            .HasConversion(c => c.Value, value => ContractorId.Create(value));
    }
}