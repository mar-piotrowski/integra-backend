using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.DeleteSchedule;

public record DeleteUserScheduleCommand(UserId UserId, ScheduleSchemaId ScheduleSchemaId) : ICommand;