namespace Application.Features.Stock;

public class StockUtils {
    public static Domain.Entities.Stock? FindMainStock(IEnumerable<Domain.Entities.Stock> stocks) =>
        stocks.FirstOrDefault(stock => stock.IsMain);
}