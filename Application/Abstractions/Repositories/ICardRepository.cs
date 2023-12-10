using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface ICardRepository : IRepository<Card, CardId> { }