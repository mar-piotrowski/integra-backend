using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Authentication;

public class UserContractsConfiguration : IEntityTypeConfiguration<UserContracts>{
    public void Configure(EntityTypeBuilder<UserContracts> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => UserContractsId.Create(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.ContractId)
            .HasConversion(c => c.Value, value => ContractId.Create(value));
    }
}