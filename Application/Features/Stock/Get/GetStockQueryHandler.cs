using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.Get;

public class GetStockQueryHandler : IQueryHandler<GetStockQuery, StockDto> {
    private readonly IStockRepository _stockRepository;
    private readonly StockMapper _stockMapper;

    public GetStockQueryHandler(IStockRepository stockRepository, StockMapper stockMapper) {
        _stockRepository = stockRepository;
        _stockMapper = stockMapper;
    }

    public async Task<Result<StockDto>> Handle(GetStockQuery request, CancellationToken cancellationToken) {
        var stock = _stockRepository.FindById(request.StockId);
        return stock is null
            ? Result.Failure<StockDto>(StockErrors.NotFound)
            : Result.Success(_stockMapper.MapToDto(stock));
    }
}