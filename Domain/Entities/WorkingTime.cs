using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class WorkingTime : Entity<WorkingTimeId> {
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int TotalSeconds { get; private set; }
    
    public IEnumerable<UserWorkingTimes> WorkingTimes { get; private set; }

    public WorkingTime() { }

    public void StartWork() {
        StartDate = DateTime.Now;
    }

    public void EndWork() {
        EndDate = DateTime.Now;
        CalculateTotalHours();
    }

    private void CalculateTotalHours() {
        if (EndDate is null)
            return;
        TotalSeconds = (int)Math.Round((EndDate.Value - StartDate).TotalSeconds);
    }
}