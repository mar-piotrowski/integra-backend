using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class UserSchedules : Entity<UserSchedulesId> {
    public UserId UserId { get; set; }
    public ScheduleSchemaId ScheduleSchemaId { get; set; }
    public User User { get; set; }
    public ScheduleSchema ScheduleSchema { get; set; }

    public UserSchedules() { }

    public UserSchedules(User user, ScheduleSchema scheduleSchema) {
        User = user;
        ScheduleSchema = scheduleSchema;
    }
}