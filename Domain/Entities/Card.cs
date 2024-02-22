using Domain.Common.Models;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Card : Entity<CardId> {
    public CardNumber Number { get; private set; }
    public bool IsActive { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }

    private Card() { }

    public Card(CardNumber number, bool active) {
        Number = number;
        if (active)
            Active();
    }

    public void Active() => IsActive = true;

    public void DeActive() => IsActive = false;
}