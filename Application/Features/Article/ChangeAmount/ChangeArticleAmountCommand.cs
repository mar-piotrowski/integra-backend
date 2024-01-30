using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.ChangeAmount;

public record ChangeArticleAmountCommand(ArticleId ArticleId, decimal Amount) : ICommand;