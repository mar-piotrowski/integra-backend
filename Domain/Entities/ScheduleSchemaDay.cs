using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class ScheduleSchemaDay : Entity<ScheduleSchemaDayId> {
    public Day Day { get; private set; }
    public DateTimeOffset StartHour { get; private set; }
    public DateTimeOffset EndHour { get; private set; }
    public ScheduleSchemaId ScheduleSchemaId { get;  private set; }
    public ScheduleSchema ScheduleSchema { get; private set; }

    public ScheduleSchemaDay(Day day, DateTimeOffset startHour, DateTimeOffset endHour) {
        Day = day;
        StartHour = startHour;
        EndHour = endHour;
    }

    public void ChangeHours(DateTimeOffset startHour, DateTimeOffset endHour) {
        StartHour = startHour;
        EndHour = endHour;
    }
}