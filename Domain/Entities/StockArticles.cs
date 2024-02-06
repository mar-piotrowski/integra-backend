using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class StockArticles : Entity<StockArticlesId> {
    public StockId StockId { get; private set; }
    public ArticleId ArticleId { get; private set; }
    public decimal Amount { get; private set; }
    public Stock Stock { get; private set; }
    public Article Article { get; private set; }

    public StockArticles(StockId stockId, ArticleId articleId, decimal amount) {
        StockId = stockId;
        ArticleId = articleId;
        Amount = amount;
    }
    
    public StockArticles(Stock stock, Article article, decimal amount) {
        Stock = stock;
        Article = article;
        Amount = amount;
    }

    public void ChangeAmount(decimal amount) => Amount = amount;

    public void Odd(decimal amount) => Amount -= amount;
    
    public void Add(decimal amount) => Amount += amount;
}