using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SchoolHistoryConfiguration : IEntityTypeConfiguration<SchoolHistory> {
    public void Configure(EntityTypeBuilder<SchoolHistory> builder) {
        builder.ToTable("schoolHistories");
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => SchoolHistoryId.Create(value))
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}