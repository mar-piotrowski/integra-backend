using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.ChangeAmount;

public class ChangeArticleAmountCommandHandler : ICommandHandler<ChangeArticleAmountCommand> {
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeArticleAmountCommandHandler(
        IArticleRepository articleRepository,
        IUnitOfWork unitOfWork
    ) {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ChangeArticleAmountCommand request, CancellationToken cancellationToken) {
        var article = _articleRepository.FindById(request.ArticleId);
        if (article is null)
            return Result.Failure(ArticleErrors.NotFound);
        article.ChangeAmount(request.Amount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}