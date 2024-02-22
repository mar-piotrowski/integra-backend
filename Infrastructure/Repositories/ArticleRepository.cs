using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ArticleRepository : Repository<Article, ArticleId>, IArticleRepository {
    public ArticleRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override Article? FindById(ArticleId id) =>
        DbContext.Set<Article>()
            .Where(a => a.Active)
            .Include(s => s.Stocks)
            .ThenInclude(s => s.Stock)
            .FirstOrDefault(article => article.Id == id);

    public override IEnumerable<Article> FindAll() =>
        DbContext.Set<Article>()
            .Where(a => a.Active)
            .Include(s => s.Stocks)
            .ThenInclude(s => s.Stock)
            .ToList();

    public Article? FindByCode(string code) =>
        DbContext.Set<Article>()
            .Where(a => a.Active)
            .Include(s => s.Stocks)
            .ThenInclude(s => s.Stock)
            .FirstOrDefault(article => article.Code == code && article.Active);

    public List<Article> FindByIds(IEnumerable<ArticleId> articleIds) =>
        DbContext.Set<Article>()
            .Where(a => a.Active)
            .Include(s => s.Stocks)
            .ThenInclude(s => s.Stock)
            .Where(article => articleIds.Contains(article.Id) && article.Active)
            .ToList();
}