using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class StockMapper {
    public StockDto MapToDto(Stock stock) => new StockDto(
        stock.Id.Value,
        stock.Name,
        stock.IsMain,
        CountAllStockArticles(stock.Articles),
        stock.Articles.MapToStockArticles()
    );

    public List<StockDto> MapToDtos(IEnumerable<Stock> stocks) => stocks.Select(MapToDto).ToList();

    private decimal CountAllStockArticles(List<StockArticles> articles) =>
        articles.Aggregate(0m, (acc, curr) => acc += curr.Amount);
}