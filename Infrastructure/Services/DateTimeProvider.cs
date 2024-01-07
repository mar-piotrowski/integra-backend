using Application.Abstractions;

namespace Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.Now;
}