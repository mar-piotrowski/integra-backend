using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class ContractConfiguration : IEntityTypeConfiguration<Contract> {
    public void Configure(EntityTypeBuilder<Contract> builder) {
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ContractId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
        builder.Property(p => p.JobPositionId)
            .HasConversion(c => c.Value, value => JobPositionId.Create(value));
        builder.Property(p => p.InsuranceCodeId)
            .HasConversion(c => c.Value, value => InsuranceCodeId.Create(value));
        builder.Property(p => p.DeductibleCostId)
            .HasConversion(c => c.Value, value => DeductibleCostId.Create(value));
    }
}