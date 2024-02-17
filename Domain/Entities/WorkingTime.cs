using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class WorkingTime : Entity<WorkingTimeId> {
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset? EndDate { get; private set; }
    public int TotalSeconds { get; private set; }
    public WorkingTimeStatus Status { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }

    public WorkingTime() { }

    public void StartWork() {
        StartDate = DateTime.Now;
        Status = WorkingTimeStatus.Start;
    }

    public void EndWork() {
        EndDate = DateTime.Now;
        Status = WorkingTimeStatus.End;
        CalculateTotalHours();
    }

    public void Update(DateTimeOffset startDate, DateTimeOffset? endDate) {
        StartDate = startDate;
        if (endDate is null) {
            EndDate = null;
            Status = WorkingTimeStatus.Start;
            TotalSeconds = 0;
            return;
        }

        EndDate = endDate;
        Status = WorkingTimeStatus.End;
        CalculateTotalHours();
    }

    private void CalculateTotalHours() {
        if (EndDate is null) {
            TotalSeconds = (int)Math.Round((DateTimeOffset.Now - StartDate).TotalSeconds);
            return;
        }

        TotalSeconds = (int)Math.Round((EndDate.Value - StartDate).TotalSeconds);
    }
}