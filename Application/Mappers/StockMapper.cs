using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class StockMapper {
    private readonly ArticleMapper _articleMapper;

    public StockMapper(ArticleMapper articleMapper) {
        _articleMapper = articleMapper;
    }

    public StockDto MapToDto(Stock stock) => new StockDto(
        stock.Id.Value,
        stock.Name,
        stock.IsMain,
        CountAllStockArticles(stock.Articles),
        _articleMapper.MapToStockArticles(stock.Articles)
    );

    public List<StockDto> MapToDtos(IEnumerable<Stock> stocks) => stocks.Select(MapToDto).ToList();

    private decimal CountAllStockArticles(List<StockArticles> articles) =>
        articles.Aggregate(0m, (acc, curr) => acc += curr.Amount);
}