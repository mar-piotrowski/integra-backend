using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserWorkingTimesConfiguration : IEntityTypeConfiguration<UserWorkingTimes> {
    public void Configure(EntityTypeBuilder<UserWorkingTimes> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserWorkingTimesId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.WorkingTimeId)
            .HasConversion(c => c.Value, value => WorkingTimeId.Create(value));
        builder.HasOne(u => u.User)
            .WithMany(u => u.WorkingTimes)
            .HasForeignKey(k => k.UserId);
        builder.HasOne(w => w.WorkingTime)
            .WithMany(w => w.WorkingTimes)
            .HasForeignKey(k => k.WorkingTimeId);
    }
}