using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ArticleRepository : Repository<Article, ArticleId>, IArticleRepository {
    public ArticleRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override IEnumerable<Article> FindAll() =>
        DbContext.Set<Article>()
            .Include(s => s.Stocks)
            .Where(article => article.Active && !article.Historical)
            .ToList();
    
    public Article? FindByCode(string code) =>
        DbContext.Set<Article>()
            .Include(s => s.Stocks)
            .FirstOrDefault(article => article.Code == code);

    public List<Article> FindByIds(IEnumerable<ArticleId> articleIds) =>
        DbContext.Set<Article>()
            .Include(s => s.Stocks)
            .Where(article => articleIds.Contains(article.Id))
            .ToList();
}