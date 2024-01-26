using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class UserWorkingTimes : Entity<UserWorkingTimesId> {
    public UserId UserId { get; private set; }
    public WorkingTimeId WorkingTimeId { get; private set; }
    public User User { get; private set; }
    public WorkingTime WorkingTime { get; private set; }

    public UserWorkingTimes() { }

    public UserWorkingTimes(User user, WorkingTime workingTime) {
        User = user;
        WorkingTime = workingTime;
    }
}