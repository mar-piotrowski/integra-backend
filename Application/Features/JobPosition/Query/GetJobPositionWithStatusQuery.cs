using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.JobPosition.Query;

public record GetJobPositionWithStatusQuery : IQuery<JobPositionWithStatsResponse>;