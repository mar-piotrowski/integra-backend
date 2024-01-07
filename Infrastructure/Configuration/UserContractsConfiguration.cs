using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class UserContractsConfiguration : IEntityTypeConfiguration<UserContracts> {
    public void Configure(EntityTypeBuilder<UserContracts> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserContractsId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
    }
}