using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class StockArticlesConfiguration  : IEntityTypeConfiguration<StockArticles> {
    public void Configure(EntityTypeBuilder<StockArticles> builder) {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id)
            .HasConversion(c => c.Value, value => new StockArticlesId(value))
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.HasOne(s => s.Article)
            .WithMany(a => a.Stocks)
            .HasForeignKey(k => k.ArticleId)
            .IsRequired();
        builder.HasOne(s => s.Stock)
            .WithMany(a => a.Articles)
            .HasForeignKey(k => k.StockId)
            .IsRequired();
    }
}