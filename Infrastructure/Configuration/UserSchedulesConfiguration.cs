using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserSchedulesConfiguration : IEntityTypeConfiguration<UserSchedules> {
    public void Configure(EntityTypeBuilder<UserSchedules> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserSchedulesId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.ScheduleSchemaId)
            .HasConversion(c => c.Value, value => ScheduleSchemaId.Create(value));
        builder.HasOne(u => u.User)
            .WithMany(s => s.Schedules)
            .HasForeignKey(k => k.UserId)
            .IsRequired();
        builder.HasOne(s => s.ScheduleSchema)
            .WithMany(s => s.Schedules)
            .HasForeignKey(k => k.ScheduleSchemaId)
            .IsRequired();
    }
}