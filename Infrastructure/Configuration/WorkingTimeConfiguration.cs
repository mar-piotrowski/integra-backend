using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime> {
    public void Configure(EntityTypeBuilder<WorkingTime> builder) {
        builder.HasKey(a => a.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => WorkingTimeId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}