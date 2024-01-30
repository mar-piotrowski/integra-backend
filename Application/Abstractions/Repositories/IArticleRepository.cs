using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IArticleRepository : IRepository<Article, ArticleId> {
    public Article? GetByCode(string code);
}