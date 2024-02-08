namespace Application.Dtos;

public record StockDto(int Id, string Name, bool IsMain, decimal TotalProductsAmount, List<StockArticleDto> Articles);