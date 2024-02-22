using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.Update;

public class EditStockCommandHandler : ICommandHandler<EditStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EditStockCommandHandler(IStockRepository stockRepository, IUnitOfWork unitOfWork) {
        _stockRepository = stockRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(EditStockCommand request, CancellationToken cancellationToken) {
        var stock = _stockRepository.FindById(request.StockId);
        if (stock is null)
            return Result.Failure(StockErrors.NotFound);
        var stockNameExists = _stockRepository.FindByName(request.Name);
        if (stockNameExists is not null && stock.Id != stockNameExists.Id)
            return Result.Failure(StockErrors.NameExists);
        if (request.IsMain) {
            var mainStock = StockUtils.FindMainStock(_stockRepository.FindAll());
            mainStock?.IsNoLongerMain();
        }
        stock.Edit(request.Name, request.IsMain, request.Description);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}