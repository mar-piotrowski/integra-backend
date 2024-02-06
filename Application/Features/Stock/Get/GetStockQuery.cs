using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Stock.Get;

public record GetStockQuery(StockId StockId) : IQuery<StockDto>;