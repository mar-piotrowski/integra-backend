using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.GetArtcle;

public record GetArticleQuery(ArticleId ArticleId, StockId? StockId) : IQuery<ArticleDto>;