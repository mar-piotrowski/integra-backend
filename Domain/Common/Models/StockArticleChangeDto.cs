using Domain.ValueObjects.Ids;

namespace Domain.Common.Models;

public record StockArticleChangeDto(ArticleId ArticleId, decimal Amount);