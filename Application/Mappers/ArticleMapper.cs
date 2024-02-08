using Application.Dtos;
using Domain.Common.Models;
using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Mappers;

public static class ArticleMapper {
    public static ArticleDto MapToDto(this Article article) => new ArticleDto(
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
        0,
        article.Description
    );

    public static List<ArticleDto> MapToDtos(this IEnumerable<Article> articles) =>
        articles.Select(article => article.MapToDto()).ToList();

    public static DocumentArticleDto MapToDocumentArticleDto(this DocumentArticles documentArticle) =>
        new DocumentArticleDto(
            documentArticle.Article.Id.Value,
            documentArticle.Article.Name,
            documentArticle.Article.Code,
            documentArticle.Article.Gtin,
            documentArticle.Article.MeasureUnit,
            documentArticle.Article.Pkwiu,
            documentArticle.Article.SellPriceWithoutTax,
            documentArticle.Article.SellPriceWithTax,
            documentArticle.Article.Tax,
            documentArticle.Amount,
            documentArticle.Article.Description
        );

    public static List<DocumentArticleDto> MapToDocumentArticleDtos(this List<DocumentArticles> articles) =>
        articles.Select(documentArticles => documentArticles.MapToDocumentArticleDto()).ToList();

    public static List<StockArticleChangeDto> MapToAddArticles(this List<CreateDocumentArticleDto> articles) =>
        articles.Select(article => new StockArticleChangeDto(ArticleId.Create(article.ArticleId), article.Amount))
            .ToList();

    public static List<StockArticleDto> MapToStockArticles(this List<StockArticles> articles) =>
        articles.Select(article => new StockArticleDto(article.Article.Name, article.Article.Code, article.Amount))
            .ToList();
}