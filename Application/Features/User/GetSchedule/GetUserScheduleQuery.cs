using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.GetSchedule;

public record GetUserScheduleQuery(UserId UserId, int Year, int Month, bool OnlyWeek) : IQuery<UserScheduleResponse>;