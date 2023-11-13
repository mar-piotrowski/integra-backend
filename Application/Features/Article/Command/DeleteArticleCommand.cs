using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.Command;

public record DeleteArticleCommand(ArticleId Id) : ICommand;