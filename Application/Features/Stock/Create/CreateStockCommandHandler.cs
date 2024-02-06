using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.Create;

public class CreateStockCommandHandler : ICommandHandler<CreateStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStockCommandHandler(IStockRepository stockRepository, IUnitOfWork unitOfWork) {
        _stockRepository = stockRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateStockCommand request, CancellationToken cancellationToken) {
        var stockNameExists = _stockRepository.FindByName(request.Name);
        if (stockNameExists is not null)
            return Result.Failure(StockErrors.NameExists);
        if (request.IsMain) {
            var mainStock = StockUtils.FindMainStock(_stockRepository.FindAll());
            mainStock?.IsNoLongerMain();
        }

        var newStock = new Domain.Entities.Stock(request.Name, request.IsMain, request.Description);
        _stockRepository.Add(newStock);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}