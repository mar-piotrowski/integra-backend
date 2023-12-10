using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class WorkingTime : Entity<WorkingTimeId> {
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime StartWorkDate { get; private set; }
    public DateTime EndWorkDate { get; private set; }
    public CardId CardId { get; private set; }
    public Card Card { get; private set; }
    public string? Description { get; private set; }

    private WorkingTime() { }

    public WorkingTime(DateTime startDate, DateTime endDate, DateTime startWorkDate, DateTime endWorkDate) {
        StartDate = startDate;
        EndDate = endDate;
        StartWorkDate = startWorkDate;
        EndWorkDate = endWorkDate;
    }
}