using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Models;
using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Mappers;

public class ArticleMapper {
    private readonly IStockRepository _stockRepository;

    public ArticleMapper(IStockRepository stockRepository) {
        _stockRepository = stockRepository;
    }

    public ArticleDto MapToDto(Article article) {
        return new ArticleDto(
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
            _stockRepository.CountArticleOnStocks(article.Id),
            article.Description
        );
    }

    public List<ArticleDto> MapToDtos(IEnumerable<Article> articles) =>
        articles.Select(MapToDto).ToList();

    public DocumentArticleDto MapToDocumentArticleDto(DocumentArticles documentArticle) =>
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

    public List<DocumentArticleDto> MapToDocumentArticleDtos(List<DocumentArticles> articles) =>
        articles.Select(MapToDocumentArticleDto).ToList();

    public List<StockArticleChangeDto> MapToAddArticles(List<CreateDocumentArticleDto> articles) =>
        articles.Select(article => new StockArticleChangeDto(ArticleId.Create(article.Id), article.Amount))
            .ToList();

    public List<StockArticleDto> MapToStockArticles(List<StockArticles> articles) =>
        articles.Select(article => new StockArticleDto(article.Article.Name, article.Article.Code, article.Amount))
            .ToList();
}