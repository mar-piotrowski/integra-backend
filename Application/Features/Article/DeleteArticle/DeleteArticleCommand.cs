using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.DeleteArticle;

public record DeleteArticleCommand(ArticleId Id) : ICommand;