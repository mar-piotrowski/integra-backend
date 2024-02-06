using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.AddProduct;

public class AddProductToStockCommandHandler : ICommandHandler<AddProductToStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IArticleRepository _articleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProductToStockCommandHandler(
        IStockRepository stockRepository,
        IArticleRepository articleRepository,
        IUnitOfWork unitOfWork
    ) {
        _stockRepository = stockRepository;
        _articleRepository = articleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddProductToStockCommand request, CancellationToken cancellationToken) {
        var stock = _stockRepository.FindById(request.StockId);
        if (stock is null)
            return Result.Failure(StockErrors.NotFound);
        var article = _articleRepository.FindByCode(request.ArticleCode);
        if (article is null)
            return Result.Failure(ArticleErrors.NotFound);
        if (stock.Articles.Exists(stockArticle => stockArticle.Article == article)) 
            stock.ChangeArticleAmount(article, request.Amount);
        else 
            stock.AddArticle(article, request.Amount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}