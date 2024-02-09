using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Features.Document;

public static class DocumentUtils {
    public static Result HasAvailableArticles(
        List<Domain.Entities.Article> articles,
        List<CreateDocumentArticleDto> articlesToAdd
    ) {
        foreach (var requestArticle in articlesToAdd)
            if (!articles.Exists(article => article.Id == ArticleId.Create(requestArticle.Id)))
                return Result.Failure(ArticleErrors.NotFound);
        return Result.Success();
    }

    public static void AddArticles(
        Domain.Entities.Document document,
        List<Domain.Entities.Article> articles,
        List<CreateDocumentArticleDto> articlesToAdd
    ) {
        var articlesToAddSortedById = articlesToAdd.OrderBy(article => article.Id).ToList();
        var sortedArticles = articles.OrderBy(article => article.Id).ToList();
        for (var i = 0; i < articles.Count; i++)
            document.AddArticle(sortedArticles[i], articlesToAddSortedById[i].Amount);
    }

    public static Result ProductsOnStock(
        List<CreateDocumentArticleDto> articles,
        List<Domain.Entities.Stock> stockWithProduct
    ) {
        if (stockWithProduct.Any())
            return Result.Failure<Domain.Entities.Document>(StockErrors.NoArticleOnStock);
        foreach (var article in articles) {
            foreach (var stock in stockWithProduct) {
                var stockArticle = stock
                    .Articles
                    .FirstOrDefault(a => a.ArticleId == ArticleId.Create(article.Id));
                if (stockArticle is null)
                    return Result.Failure<Domain.Entities.Document>(StockErrors.NoArticleOnStock);
                if (stockArticle.Amount < article.Amount)
                    return Result.Failure<Domain.Entities.Document>(
                        StockErrors.NotEnoughAmountOnStock(stockArticle.Article.Name, stockArticle.Amount));
            }
        }

        return Result.Success();
    }
}