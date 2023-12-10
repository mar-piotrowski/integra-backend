using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class HolidayLimit : Entity<HolidayLimitId> {
    public DateTime Current { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int AvailableDays { get; private set; }
    public int UsedDays { get; private set; }
    public int MergedDays { get; private set; }
    public string Description { get; private set; }
    public UserId UserId { get; private set; }
    public User User { get; private set; }

    private HolidayLimit(
        UserId userId, 
        DateTime current,
        DateTime startDate,
        DateTime endDate,
        int availableDays,
        string description = "",
        int usedDays = 0,
        int mergedDays = 0
    ) {
        Current = current;
        StartDate = startDate;
        EndDate = endDate;
        AvailableDays = availableDays;
        UserId = userId;
        Description = description;
        UsedDays = usedDays;
        MergedDays = mergedDays;
    }

    public static HolidayLimit Create(
        UserId userId, 
        DateTime current,
        DateTime startDate,
        DateTime endDate,
        int availableDays,
        string description = "",
        int usedDays = 0,
        int mergedDays = 0
    ) =>
        new HolidayLimit(userId, current, startDate, endDate, availableDays, description, usedDays, mergedDays);
}