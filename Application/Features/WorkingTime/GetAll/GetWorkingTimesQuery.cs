using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.WorkingTime.GetAll;

public record GetWorkingTimesQuery(UserId? UserId) : IQuery<WorkingTimesResponse>;