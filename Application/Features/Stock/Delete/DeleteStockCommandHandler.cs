using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.Delete;

public class DeleteStockCommandHandler : ICommandHandler<DeleteStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockCommandHandler(IStockRepository stockRepository, IUnitOfWork unitOfWork) {
        _stockRepository = stockRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStockCommand request, CancellationToken cancellationToken) {
        var stock = _stockRepository.FindById(request.StockId);
        if (stock is null)
            return Result.Failure(StockErrors.NotFound);
        var stockHasProducts = stock.Articles.Any();
        if (stockHasProducts)
            return Result.Failure(StockErrors.CanNotDeleteWithProducts);
        _stockRepository.Remove(stock);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}