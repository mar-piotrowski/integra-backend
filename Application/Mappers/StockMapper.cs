using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class StockMapper {
    public static StockDto MapToDto(this Stock stock) =>
        new StockDto(stock.Id.Value, stock.Name, stock.Location);

    public static List<StockDto> MapToDtos(this IEnumerable<Stock> stocks) =>
        stocks.Select(stock => stock.MapToDto()).ToList();
}