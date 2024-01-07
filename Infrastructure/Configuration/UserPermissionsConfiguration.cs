using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserPermissionsConfiguration : IEntityTypeConfiguration<UserPermissions> {
    public void Configure(EntityTypeBuilder<UserPermissions> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserPermissionsId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.HasOne(u => u.User)
            .WithMany(u => u.Permissions)
            .HasForeignKey(k => k.UserId);
        builder.HasOne(p => p.Permission)
            .WithMany(p => p.Permissions)
            .HasForeignKey(k => k.PermissionId);
    }
}