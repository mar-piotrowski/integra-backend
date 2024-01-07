using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.HolidayLimit.CreateHolidayLimit;

public record CreateHolidayLimitCommand(
    UserId UserId,
    DateTime Current,
    DateTime StartDate,
    DateTime EndDate,
    string Description
) : ICommand;