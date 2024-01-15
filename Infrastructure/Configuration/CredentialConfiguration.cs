using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CredentialConfiguration : IEntityTypeConfiguration<Credential> {
    public void Configure(EntityTypeBuilder<Credential> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => CredentialId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}