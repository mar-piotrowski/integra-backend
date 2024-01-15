using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class HolidayLimitConfiguration : IEntityTypeConfiguration<HolidayLimit> {
    public void Configure(EntityTypeBuilder<HolidayLimit> builder) {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => HolidayLimitId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}