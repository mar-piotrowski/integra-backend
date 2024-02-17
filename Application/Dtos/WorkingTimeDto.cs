using Domain.Enums;

namespace Application.Dtos;

public record WorkingTimeDto(
    int Id,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate,
    decimal TotalSeconds,
    WorkingTimeStatus Status,
    UserShortDto User
);