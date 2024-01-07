using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Article.GetArticles;

public record GetArticlesQuery : IQuery<ArticlesResponse>;