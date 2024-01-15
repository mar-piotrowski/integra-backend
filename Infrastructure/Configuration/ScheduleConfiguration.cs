using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule> {
    public void Configure(EntityTypeBuilder<Schedule> builder) {
        builder.HasKey(a => a.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ScheduleId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}