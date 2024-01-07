using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission> {
    public void Configure(EntityTypeBuilder<Permission> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => PermissionId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Code)
            .HasConversion(c => c.Value, value => PermissionCode.Create(value));
    }
}