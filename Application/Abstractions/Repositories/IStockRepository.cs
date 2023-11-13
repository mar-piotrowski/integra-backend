using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IStockRepository : IRepository<Stock, StockId> {
    public Stock? FindByName(string name);
}