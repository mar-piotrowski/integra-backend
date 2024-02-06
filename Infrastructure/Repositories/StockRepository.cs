using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StockRepository : Repository<Stock, StockId>, IStockRepository {
    public StockRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override IEnumerable<Stock> FindAll() =>
        DbContext.Set<Stock>()
            .Include(a => a.Articles)
            .ThenInclude(a => a.Article)
            .ToList();

    public Stock? FindByName(string name) =>
        DbContext.Set<Stock>().FirstOrDefault(entry => entry.Name == name);

    public List<Stock> FindStocksWithProduct(ArticleId articleId) =>
        FindAll()
            .Where(stock => stock.Articles.Exists(a => a.ArticleId == articleId))
            .ToList();

    public List<Article> FindArticles(StockId stockId, List<ArticleId> articleIds) {
        var stock = DbContext.Set<Stock>()
            .Include(stock => stock.Articles)
            .ThenInclude(stockArticles => stockArticles.Article)
            .FirstOrDefault(stock => stock.Id == stockId);
        if (stock is null)
            return new List<Article>();
        return stock.Articles
            .Where(article => articleIds.Contains(article.ArticleId))
            .Select(article => article.Article).ToList();
    }
}