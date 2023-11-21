using Application.Abstractions;
using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Result;
using Domain.ValueObjects;

namespace Application.Features.Stock.Command;

public class CreateStockCommandHandler : ICommandHandler<CreateStockCommand> {
    private readonly IStockRepository _stockRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStockCommandHandler(IStockRepository stockRepository, IUnitOfWork unitOfWork) {
        _stockRepository = stockRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateStockCommand request, CancellationToken cancellationToken) {
        var stockExists = _stockRepository.FindByName(request.Name);
        if (stockExists is not null)
            return Result.Failure(StockErrors.StockExists);
        var location = request.Location is not null
            ? Location.Create(
                request.Location.Street,
                request.Location.HouseNo,
                request.Location.ApartmentNo,
                request.Location.PostalCode,
                request.Location.City,
                request.Location.Country,
                request.Location.IsCompany,
                request.Location.IsPrivate
            )
            : null;
        var stock = Domain.Entities.Stock.Create(request.Name, location);
        _stockRepository.Add(stock);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}