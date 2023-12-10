using Domain.ValueObjects;

namespace Application.Dtos;

public record StockDto(int Id, string Name, Location? Location);