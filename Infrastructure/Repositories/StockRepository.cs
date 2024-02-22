using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StockRepository : Repository<Stock, StockId>, IStockRepository {
    public StockRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override Stock? FindById(StockId id) =>
        DbContext.Set<Stock>()
            .Include(a => a.Articles.Where(a => a.Article.Active))
            .ThenInclude(a => a.Article)
            .FirstOrDefault(s => s.Id == id);

    public override IEnumerable<Stock> FindAll() =>
        DbContext.Set<Stock>()
            .Include(a => a.Articles.Where(a => a.Article.Active))
            .ThenInclude(a => a.Article)
            .ToList();

    public Stock? FindByName(string name) =>
        DbContext.Set<Stock>().FirstOrDefault(entry => entry.Name == name);

    public List<Stock> FindStocksWithProduct(ArticleId articleId) =>
        FindAll()
            .Where(stock => stock.Articles.Exists(a => a.ArticleId == articleId && a.Article.Active))
            .ToList();

    public List<Article> FindArticles(StockId stockId, List<ArticleId> articleIds) {
        var stock = DbContext.Set<Stock>()
            .Include(stock => stock.Articles)
            .ThenInclude(stockArticles => stockArticles.Article)
            .FirstOrDefault(stock => stock.Id == stockId);
        if (stock is null)
            return new List<Article>();
        return stock.Articles
            .Where(article => article.Article.Active)
            .Where(article => articleIds.Contains(article.ArticleId))
            .Select(article => article.Article).ToList();
    }

    public decimal CountArticleOnStocks(ArticleId articleId) =>
        FindAll()
            .Aggregate(0m, (acc, curr) => {
                var article = curr
                    .Articles
                    .FirstOrDefault(article => article.ArticleId == articleId && article.Article.Active);
                if (article is not null)
                    acc += article.Amount;
                return acc;
            });
}