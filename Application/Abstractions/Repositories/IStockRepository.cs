using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IStockRepository : IRepository<Stock, StockId> {
    public Stock? FindByName(string name);
    public List<Stock> FindStocksWithProduct(ArticleId articleId);
    public List<Article> FindArticles(StockId stockId, List<ArticleId> articleIds);
    public decimal CountArticleOnStocks(ArticleId articleId);
}