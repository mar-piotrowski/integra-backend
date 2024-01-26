using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Schedule.GetSchedules;

public record GetScheduleQuery(ScheduleSchemaId Id) : IQuery<ScheduleDto>;