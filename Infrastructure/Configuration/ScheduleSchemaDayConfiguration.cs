using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ScheduleSchemaDayConfiguration : IEntityTypeConfiguration<ScheduleSchemaDay> {
    public void Configure(EntityTypeBuilder<ScheduleSchemaDay> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ScheduleSchemaDayId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.ScheduleSchemaId)
            .HasConversion(c => c.Value, value => ScheduleSchemaId.Create(value));

    }
}