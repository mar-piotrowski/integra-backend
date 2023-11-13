using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class StockRepository : Repository<Stock, StockId>, IStockRepository {
    public StockRepository(DatabaseContext dbContext) : base(dbContext) { }

    public Stock? FindByName(string name) =>
        DbContext.Set<Stock>().FirstOrDefault(entry => entry.Name == name);
}