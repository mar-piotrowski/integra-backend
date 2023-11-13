using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.Queries;

public record GetArticlesQuery(StockId? StockId): IQuery<IEnumerable<ArticleResponse>>;