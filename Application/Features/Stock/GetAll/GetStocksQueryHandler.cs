using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.Stock.GetAll;

public class GetStocksQueryHandler : IQueryHandler<GetStocksQuery, StocksResponse> {
    private readonly IStockRepository _stockRepository;
    private readonly StockMapper _stockMapper;

    public GetStocksQueryHandler(IStockRepository stockRepository, StockMapper stockMapper) {
        _stockRepository = stockRepository;
        _stockMapper = stockMapper;
    }

    public async Task<Result<StocksResponse>> Handle(GetStocksQuery request, CancellationToken cancellationToken) {
        var stocks = _stockRepository.FindAll().ToList();
        return !stocks.Any()
            ? Result.Failure<StocksResponse>(StockErrors.NotFoundMany)
            : Result.Success(new StocksResponse(_stockMapper.MapToDtos(stocks)));
    }
}