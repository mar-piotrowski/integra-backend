using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class Schedule : Entity<ScheduleId> {
    public DateTime Date { get; private set; }
    public DateTime StartWorkTime { get; private set; }
    public DateTime EndWorkTime { get; private set; }
    public string? Description { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }
}