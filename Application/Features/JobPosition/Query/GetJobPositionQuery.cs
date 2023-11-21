using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobPosition.Query; 

public record GetJobPositionQuery(JobPositionId JobPositionId) : IQuery<JobPositionDto>;