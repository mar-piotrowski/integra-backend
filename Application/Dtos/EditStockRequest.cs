namespace Application.Dtos;

public record EditStockRequest(string Name, bool IsMain, string? Description);