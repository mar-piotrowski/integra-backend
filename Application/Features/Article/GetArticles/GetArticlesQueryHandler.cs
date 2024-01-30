using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.GetArticles;

public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, ArticlesResponse> {
    private readonly IArticleRepository _articleRepository;

    public GetArticlesQueryHandler(IArticleRepository articleRepository) {
        _articleRepository = articleRepository;
    }

    public async Task<Result<ArticlesResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken) {
        var articles = _articleRepository.FindAll().ToList();
        return !articles.Any()
            ? Result.Failure<ArticlesResponse>(ArticleErrors.NotFoundMany)
            : Result.Success( new ArticlesResponse(_articleRepository.Count(), articles.MapToDtos()));
    }
}