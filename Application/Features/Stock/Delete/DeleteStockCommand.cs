using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Stock.Delete;

public record DeleteStockCommand(StockId StockId) : ICommand;