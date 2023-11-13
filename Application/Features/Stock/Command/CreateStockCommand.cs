using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Stock.Command;

public record CreateStockCommand(string Name, LocationDto? Location) : ICommand;