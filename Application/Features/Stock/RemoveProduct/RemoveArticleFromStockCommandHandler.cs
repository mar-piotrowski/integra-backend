using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.RemoveProduct;

public class RemoveArticleFromStockCommandHandler : ICommandHandler<RemoveArticleFromStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveArticleFromStockCommandHandler(
        IStockRepository stockRepository,
        IArticleRepository articleRepository,
        IUnitOfWork unitOfWork
    ) {
        _stockRepository = stockRepository;
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveArticleFromStockCommand request, CancellationToken cancellationToken) {
        var stock = _stockRepository.FindById(request.StockId);
        if (stock is null)
            return Result.Failure(StockErrors.NotFound);
        var article = _articleRepository.FindByCode(request.ArticleCode);
        if (article is null)
            return Result.Failure(ArticleErrors.NotFound);
        var stockArticle = stock.Articles.FirstOrDefault(stockArticle => stockArticle.Article == article);
        if (stockArticle is null)
            return Result.Failure(StockErrors.NoArticleOnStock);
        if (stockArticle.Amount != 0)
            return Result.Failure(StockErrors.CanNotDeleteArticleWhenAmountIsNotZero);
        stock.RemoveArticle(article);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}