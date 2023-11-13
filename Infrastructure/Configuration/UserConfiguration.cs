using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("users");
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserId.Create(value))
            .ValueGeneratedOnAdd();
        builder.Property(p => p.Phone)
            .HasConversion(c => c.Value, value => Phone.Create(value));
        builder.Property(i => i.IdentityNumber)
            .HasConversion(c => c.Value, value => IdentityNumber.Create(value));
        builder.Property(e => e.Email)
            .HasConversion(c => c.Value, value => Email.Create(value));
    }
}