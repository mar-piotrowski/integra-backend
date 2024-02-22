namespace Application.Dtos;

public record EditWorkingTimeRequest(
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate
);