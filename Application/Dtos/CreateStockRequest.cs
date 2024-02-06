namespace Application.Dtos;

public record CreateStockRequest(string Name, bool IsMain, string? Description);