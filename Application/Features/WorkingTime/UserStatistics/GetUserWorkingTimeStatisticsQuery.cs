using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.WorkingTime.UserStatistics;

public record GetUserWorkingTimeStatisticsQuery(UserId UserId, int Year, int Month)
    : IQuery<GetUserWorkingTimeStatisticsResponse>;