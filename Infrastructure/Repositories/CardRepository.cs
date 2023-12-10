using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class CardRepository : Repository<Card, CardId> {
    public CardRepository(DatabaseContext dbContext) : base(dbContext) { }
}