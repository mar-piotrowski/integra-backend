using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Card : Entity<CardId> {
    public CardNumber Number { get; private set; }
    public bool IsActive { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }
    private readonly List<Permission> _permissions = new List<Permission>();

    public IReadOnlyList<Permission> Permissions => _permissions.AsReadOnly();

    private Card() { }

    private Card(CardNumber number, UserId userId) {
        Number = number;
        UserId = userId;
        Active();
    }

    public static Card Create(UserId userId, CardNumber number) => new Card(number, userId);

    public void Active() => IsActive = true;

    public void DeActive() => IsActive = false;
}