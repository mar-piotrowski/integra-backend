using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.WorkingTime.Edit;

public record EditWorkingTimeCommand(
    WorkingTimeId WorkingTimeId,
    DateTimeOffset StartDate,
    DateTimeOffset? EndDate
) : ICommand;