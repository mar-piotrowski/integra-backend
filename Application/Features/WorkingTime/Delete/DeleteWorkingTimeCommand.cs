using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.WorkingTime.Delete;

public record DeleteWorkingTimeCommand(WorkingTimeId WorkingTimeId) : ICommand;