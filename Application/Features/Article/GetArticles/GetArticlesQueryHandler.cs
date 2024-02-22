using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.GetArticles;

public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, ArticlesResponse> {
    private readonly IArticleRepository _articleRepository;
    private readonly ArticleMapper _articleMapper;

    public GetArticlesQueryHandler(IArticleRepository articleRepository, ArticleMapper articleMapper) {
        _articleRepository = articleRepository;
        _articleMapper = articleMapper;
    }

    public async Task<Result<ArticlesResponse>> Handle(GetArticlesQuery request, CancellationToken cancellationToken) {
        var articles = _articleRepository.FindAll().ToList();
        return !articles.Any()
            ? Result.Failure<ArticlesResponse>(ArticleErrors.NotFoundMany)
            : Result.Success(new ArticlesResponse(_articleRepository.Count(), _articleMapper.MapToDtos(articles)));
    }
}