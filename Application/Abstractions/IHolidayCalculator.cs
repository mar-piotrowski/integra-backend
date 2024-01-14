using Domain.Common.Models;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions;

public interface IHolidayCalculator {
    public Result<CalculatedHolidayLimit> CalculateLimit(UserId userId, DateTime start, DateTime end);
}