using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.AddSchedule;

public record AddUserScheduleCommand(UserId UserId, ScheduleSchemaId ScheduleSchemaId) : ICommand;