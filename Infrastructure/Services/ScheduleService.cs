using Application.Abstractions;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Features.User.GetSchedule;
using Application.Mappers;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Services;

public class ScheduleService : IScheduleService {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly UserMapper _userMapper;

    public ScheduleService(IDateTimeProvider dateTimeProvider, UserMapper userMapper) {
        _dateTimeProvider = dateTimeProvider;
        _userMapper = userMapper;
    }

    public UserScheduleDto CreateUserSchedule(User user, int year, int month, bool onlyWeek) {
        var days = onlyWeek ? WeekSchedule(user.Schedules, year, month) : MonthSchedule(user.Schedules, year, month);
        return new UserScheduleDto(year, month, CalculateTotalHours(days), _userMapper.MapToShortDto(user), days);
    }

    public List<UserScheduleDto> CreateUsersSchedule(IEnumerable<User> users, int year, int month, bool onlyWeek) {
        var usersWithSchedule = new List<UserScheduleDto>();
        foreach (var user in users) {
            var days = onlyWeek
                ? WeekSchedule(user.Schedules, year, month)
                : MonthSchedule(user.Schedules, year, month);
            usersWithSchedule.Add(new UserScheduleDto(
                year,
                month,
                CalculateTotalHours(days),
                _userMapper.MapToShortDto(user),
                days
            ));
        }

        return usersWithSchedule;
    }

    private List<ScheduleDayDto> MonthSchedule(IEnumerable<UserSchedules> schemas, int year, int month) {
        var days = new List<ScheduleDayDto>();
        foreach (var schema in schemas) {
            var schedule = schema.ScheduleSchema;
            var scheduleDateRange = MonthRange(
                new DateTime(year, month, 1),
                schedule.StartDate.UtcDateTime
            );
            days.AddRange(CreateDays(schedule.Days, scheduleDateRange.Start, scheduleDateRange.End));
        }

        return days.OrderBy(day => day.Day).ToList();
    }

    private List<ScheduleDayDto> WeekSchedule(IEnumerable<UserSchedules> schemas, int year, int month) {
        var days = new List<ScheduleDayDto>();
        foreach (var schema in schemas) {
            var schedule = schema.ScheduleSchema;
            var scheduleDateRange = WeekRange(new DateTime(year, month, 1), schedule.StartDate.UtcDateTime);
            days.AddRange(CreateDays(schedule.Days, scheduleDateRange.Start, scheduleDateRange.End));
        }

        return days;
    }

    private IEnumerable<ScheduleDayDto> CreateDays(
        IReadOnlyCollection<ScheduleSchemaDay> schemaDays,
        DateTimeOffset startDate,
        DateTimeOffset? endDate
    ) {
        var days = new List<ScheduleDayDto>();
        var totalDays = CalculateTotalDays(startDate, endDate);
        for (var i = 1; i <= totalDays + 1; i++) {
            var dayNumber = i % 7 == 0 ? 7 : i % 7;
            var addDay = i == 1 ? 0 : i - 1;
            var daySchema = schemaDays.FirstOrDefault(day => (int)day.Day == dayNumber);
            if (daySchema is null)
                continue;
            var day = new ScheduleDayDto(
                daySchema.ScheduleSchemaId.Value,
                (Day)dayNumber,
                CreateNewDay(startDate, addDay, daySchema.StartHour.Hour, daySchema.StartHour.Minute),
                CreateNewDay(startDate, addDay, daySchema.EndHour.Hour, daySchema.EndHour.Minute)
            );
            days.Add(day);
        }

        return days;
    }

    private DateRange WeekRange(DateTime scheduleStart, DateTime scheduleSchemaStart) =>
        scheduleStart.DayOfWeek == scheduleSchemaStart.DayOfWeek
            ? new DateRange(scheduleStart, _dateTimeProvider.EndOfWeek(scheduleSchemaStart))
            : new DateRange(_dateTimeProvider.StartOfWeek(scheduleStart), _dateTimeProvider.EndOfWeek(scheduleStart));

    private DateRange MonthRange(DateTime scheduleStart, DateTime scheduleSchemaStart) =>
        scheduleSchemaStart.Month == scheduleStart.Month
            ? new DateRange(scheduleStart, _dateTimeProvider.EndOfMonth(scheduleStart))
            : new DateRange(_dateTimeProvider.StartOfMonth(scheduleStart), _dateTimeProvider.EndOfMonth(scheduleStart));

    private static int CalculateTotalDays(DateTimeOffset start, DateTimeOffset? end) {
        if (end is null)
            return (int)(new DateTime().AddMonths(12) - start).TotalDays;
        return (int)(end.Value - start).TotalDays;
    }

    private static decimal CalculateTotalHours(IEnumerable<ScheduleDayDto> days) => days.Aggregate(0m,
        (acc, curr) => acc += Convert.ToDecimal(Math.Round((curr.EndDate - curr.StartDate).TotalHours, 2)));

    private static DateTimeOffset CreateNewDay(DateTimeOffset date, int dayNumber, int hour, int minute) =>
        date.AddDays(dayNumber).AddHours(hour).AddMinutes(minute);
}