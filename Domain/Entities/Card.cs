using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Card : Entity<CardId> {
    public string Number { get; private set; }
    public bool Active { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }
    private readonly List<string> _permissions = new List<string>();
    private readonly List<WorkingTime> _workingTimes = new List<WorkingTime>();

    public IReadOnlyList<string> Permissions => _permissions.AsReadOnly();

    public IReadOnlyList<WorkingTime> WorkingTimes => _workingTimes.AsReadOnly();

    private Card() { }

    public Card(string number) {
        Number = number;
        Active = true;
    }

    public void DeActive() => Active = false;
}