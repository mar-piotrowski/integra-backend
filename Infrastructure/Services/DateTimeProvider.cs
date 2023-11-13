using Application.Abstractions;

namespace Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow { get; } = DateTime.Now;
}