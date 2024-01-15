using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class InsuranceCodeConfiguration : IEntityTypeConfiguration<InsuranceCode> {
    public void Configure(EntityTypeBuilder<InsuranceCode> builder) {
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => InsuranceCodeId.Create(value));
    }
}