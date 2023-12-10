using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration; 

public class JobHistoryConfiguration : IEntityTypeConfiguration<JobHistory> {
    public void Configure(EntityTypeBuilder<JobHistory> builder) {
        builder.ToTable("jobHistories");
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => JobHistoryId.Create(value))
            .ValueGeneratedOnAdd();
        builder.Property(p => p.UserId)
            .HasConversion(c => c.Value, value => UserId.Create(value));
    }
}