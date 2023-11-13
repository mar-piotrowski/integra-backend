using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location> {
    public void Configure(EntityTypeBuilder<Location> builder) {
        builder.ToTable("locations");
        builder.Property<int>("id")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasKey("id");
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}