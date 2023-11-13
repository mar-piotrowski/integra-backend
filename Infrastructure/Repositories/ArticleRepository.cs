using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class ArticleRepository : Repository<Article, ArticleId>, IArticleRepository {
    public ArticleRepository(DatabaseContext dbContext) : base(dbContext) { }

    public Article? GetByCode(string code) =>
        DbContext.Set<Article>().FirstOrDefault(article => article.Code == code);
}