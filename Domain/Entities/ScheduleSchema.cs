using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class ScheduleSchema : Entity<ScheduleSchemaId> {
    public string Name { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset? EndDate { get; private set; }
    public decimal TotalHours { get; private set; }
    public List<ScheduleSchemaDay> Days { get; private set; } = new List<ScheduleSchemaDay>();
    public virtual List<UserSchedules> Schedules { get; private set; } = new List<UserSchedules>();

    public ScheduleSchema() { }

    public ScheduleSchema(string name, DateTimeOffset startDate, DateTimeOffset? endDate, IEnumerable<ScheduleSchemaDay> days) {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Days.AddRange(days);
        CalculateTotalHours();
    }

    public void Update(string name, DateTimeOffset startDate, DateTimeOffset? endDate) {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        CalculateTotalHours();
    }

    public decimal CalculateTotalHours() => TotalHours = Days.Aggregate(0m,
        (acc, curr) => acc += Convert.ToDecimal(Math.Round((curr.EndHour - curr.StartHour).TotalHours, 2)));
}