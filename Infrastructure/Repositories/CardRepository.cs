using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CardRepository : Repository<Card, CardId>, ICardRepository {
    public CardRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override IEnumerable<Card> GetAll() =>
        DbContext.Set<Card>().Include(u => u.User).ToList();

    public Card? GetByNumber(CardNumber cardNumber) =>
        DbContext.Set<Card>().Include(u => u.User).FirstOrDefault(card => card.Number == cardNumber);
}