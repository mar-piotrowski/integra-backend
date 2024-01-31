using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class DocumentArticlesConfiguration : IEntityTypeConfiguration<DocumentArticles> {
    public void Configure(EntityTypeBuilder<DocumentArticles> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => DocumentProductsId.Create(value));
        builder.HasOne(a => a.Article)
            .WithMany(a => a.Document)
            .HasForeignKey(k => k.ArticleId);
        builder.HasOne(d => d.Document)
            .WithMany(a => a.Articles)
            .HasForeignKey(k => k.DocumentId);
    }
}