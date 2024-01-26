namespace Application.Abstractions;

public interface IDateTimeProvider {
    public DateTime UtcNow();
    public DateTime StartOfMonth(DateTimeOffset date);
    public DateTime EndOfMonth(DateTimeOffset date);
    public DateTime StartOfWeek(DateTimeOffset date);
    public DateTime EndOfWeek(DateTimeOffset date);
}