using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AbsenceStatusConfiguration : IEntityTypeConfiguration<AbsenceStatus> {
    public void Configure(EntityTypeBuilder<AbsenceStatus> builder) {
        builder.Property<int>("id")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.HasKey("id");
        builder.Property(p => p.AbsenceId)
            .HasConversion(c => c.Value, value => AbsenceId.Create(value));
    }
}