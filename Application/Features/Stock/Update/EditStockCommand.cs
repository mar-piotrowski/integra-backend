using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Stock.Update;

public record EditStockCommand(StockId StockId, string Name, bool IsMain, string? Description) : ICommand;