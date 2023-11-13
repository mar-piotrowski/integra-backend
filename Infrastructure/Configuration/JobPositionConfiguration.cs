using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition> {
    public void Configure(EntityTypeBuilder<JobPosition> builder) {
        builder.ToTable("jobPositions");
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => JobPositionId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}