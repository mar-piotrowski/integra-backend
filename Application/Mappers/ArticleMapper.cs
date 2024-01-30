using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ArticleMapper {
    public static ArticleDto MapToArticleResponse(this Article article) => new ArticleDto(
        article.Id.Value,
        article.Name,
        article.Code,
        article.Gtin,
        article.MeasureUnit,
        article.Pkwiu,
        article.BuyPriceWithoutTax,
        article.BuyPriceWithTax,
        article.SellPriceWithoutTax,
        article.SellPriceWithTax,
        article.Tax,
        article.Amount,
        article.Description
    );

    public static List<ArticleDto> MapToDtos(this IEnumerable<Article> articles) =>
        articles.Select(article => article.MapToArticleResponse()).ToList();
}