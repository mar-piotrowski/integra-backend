using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DocumentConfiguration : IEntityTypeConfiguration<Document> {
    public void Configure(EntityTypeBuilder<Document> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => DocumentId.Create(value));
        builder.Property(p => p.ContractorId)
            .HasConversion(c => c.Value, value => ContractorId.Create(value));
    }
}