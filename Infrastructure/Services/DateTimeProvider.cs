using Application.Abstractions;

namespace Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow() => DateTime.Now;
    
    public DateTime StartOfMonth(DateTimeOffset date) => new(date.Year, date.Month, 1);
    
    public DateTime EndOfMonth(DateTimeOffset date) => StartOfMonth(date).AddMonths(1).AddSeconds(-1);

    public DateTime StartOfWeek(DateTimeOffset date) => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);

    public DateTime EndOfWeek(DateTimeOffset date) {
        var startWeek = StartOfWeek(date);
        return startWeek.AddDays(7 - (int)startWeek.DayOfWeek);
    }
}