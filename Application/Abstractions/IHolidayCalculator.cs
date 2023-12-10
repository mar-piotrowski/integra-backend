using Domain.Models;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions;

public interface IHolidayCalculator {
    public CalculatedHolidayLimit CalculateLimit(UserId userId, DateTime start, DateTime end);
}