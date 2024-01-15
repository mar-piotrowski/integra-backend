using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ArticleConfiguration : IEntityTypeConfiguration<Article> {
    public void Configure(EntityTypeBuilder<Article> builder) {
        builder.HasKey(a => a.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => ArticleId.Create(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
    }
}