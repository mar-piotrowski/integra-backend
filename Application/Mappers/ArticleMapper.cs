using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ArticleMapper {
    public static ArticleResponse MapToArticleResponse(this Article article) => new ArticleResponse() {
        Name = article.Name,
        Code = article.Code,
        Gtin = article.Gtin,
        Description = article.Description,
        MeasureUnit = article.MeasureUnit,
        Pkwiu = article.Pkwiu
    };

    public static IEnumerable<ArticleResponse> MapToListArticle(this IEnumerable<Article> articles) =>
        articles.Select(article => article.MapToArticleResponse());
}