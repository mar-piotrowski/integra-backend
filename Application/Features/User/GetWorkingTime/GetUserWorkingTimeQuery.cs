using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.User.GetWorkingTime;

public record GetUserWorkingTimeQuery(UserId UserId, int Year) : IQuery<UserWorkingTimeResponse>;