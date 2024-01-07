using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.JobPosition.GetJobPositionWithStatus;

public record GetJobPositionWithStatusQuery : IQuery<JobPositionWithStatsResponse>;