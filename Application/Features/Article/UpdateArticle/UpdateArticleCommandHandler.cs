using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Article.UpdateArticle;

public class UpdateArticleCommandHandler : ICommandHandler<UpdateArticleCommand> {
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateArticleCommandHandler(IArticleRepository articleRepository, IUnitOfWork unitOfWork) {
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateArticleCommand request, CancellationToken cancellationToken) {
        var article = _articleRepository.FindById(request.Id);
        if (article is null)
            return Result.Failure(UserErrors.NotFound);
        var updateArticle = new Domain.Entities.Article(
            request.Name,
            request.Code,
            request.Gtin,
            request.MeasureUnit,
            request.Pkwiu,
            request.BuyPriceWithTax,
            request.BuyPriceWithoutTax,
            request.SellPriceWithoutTax,
            request.SellPriceWithTax,
            request.Tax,
            request.Description
        );
        article.Disable();
        _articleRepository.Add(updateArticle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}