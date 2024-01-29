using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Schedule.GetSchedule;

public record GetSchedulesQuery : IQuery<SchedulesResponse>;