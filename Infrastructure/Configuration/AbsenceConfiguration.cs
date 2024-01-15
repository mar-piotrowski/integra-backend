using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AbsenceConfiguration : IEntityTypeConfiguration<Absence> {
    public void Configure(EntityTypeBuilder<Absence> builder) {
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => AbsenceId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}