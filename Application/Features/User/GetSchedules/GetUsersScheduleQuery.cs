using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.User.GetSchedules;

public record GetUsersScheduleQuery(int Year, int Month, bool OnlyWeek) : IQuery<UsersScheduleResponse>;