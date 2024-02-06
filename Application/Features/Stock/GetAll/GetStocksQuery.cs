using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Stock.GetAll;

public record GetStocksQuery : IQuery<StocksResponse>;