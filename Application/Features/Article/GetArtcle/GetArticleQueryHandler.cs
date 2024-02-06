using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.GetArtcle;

public class GetArticleQueryHandler : IQueryHandler<GetArticleQuery, ArticleDto> {
    private readonly IArticleRepository _articleRepository;

    public GetArticleQueryHandler(IArticleRepository articleRepository) {
        _articleRepository = articleRepository;
    }
    
    public async Task<Result<ArticleDto>> Handle(GetArticleQuery request, CancellationToken cancellationToken) {
        var article = _articleRepository.FindById(request.ArticleId);
        if (article is null)
            return Result.Failure<ArticleDto>(ArticleErrors.NotFound);
        return Result.Success(article.MapToDto());
    }
}