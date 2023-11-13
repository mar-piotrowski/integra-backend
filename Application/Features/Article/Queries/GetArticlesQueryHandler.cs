using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.Article.Queries; 

public class GetArticlesQueryHandler : IQueryHandler<GetArticlesQuery, IEnumerable<ArticleResponse>> {
    private readonly IArticleRepository _articleRepository;

    public GetArticlesQueryHandler(IArticleRepository articleRepository) {
        _articleRepository = articleRepository;
    }
    public async Task<Result<IEnumerable<ArticleResponse>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken) {
        var articles = _articleRepository.GetAll();
        if(!articles.Any())
            return Result.Failure<IEnumerable<ArticleResponse>>(ArticleErrors.NotFoundMany);
        return Result.Success<IEnumerable<ArticleResponse>>(articles.MapToListArticle());
    }
}