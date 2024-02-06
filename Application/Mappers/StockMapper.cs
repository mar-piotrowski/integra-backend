using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class StockMapper {
    public StockDto MapToDto(Stock stock) => new StockDto(stock.Id.Value, stock.Name, stock.IsMain);
    
    public List<StockDto> MapToDtos(IEnumerable<Stock> stocks) => stocks.Select(MapToDto).ToList();
}