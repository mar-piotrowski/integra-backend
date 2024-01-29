using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ScheduleSchemaConfiguration : IEntityTypeConfiguration<ScheduleSchema> {
    public void Configure(EntityTypeBuilder<ScheduleSchema> builder) {
        builder.HasKey(a => a.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ScheduleSchemaId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        
    }
}