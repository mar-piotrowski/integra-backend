using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Article.Queries;

public class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, ArticleResponse> {
    private readonly IArticleRepository _articleRepository;

    public GetArticleQueryHandler(IArticleRepository articleRepository) {
        _articleRepository = articleRepository;
    }
    
    public async Task<Result<ArticleResponse>> Handle(GetArticleQuery request, CancellationToken cancellationToken) {
        var article = _articleRepository.GetById(request.ArticleId);
        if (article is null)
            return Result.Failure<ArticleResponse>(ArticleErrors.NotFoundOne);
        return Result.Success(article.MapToArticleResponse());
    }
}