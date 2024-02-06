using Application.Abstractions.Messaging;

namespace Application.Features.Stock.Create;

public record CreateStockCommand(string Name, bool IsMain, string? Description) : ICommand;