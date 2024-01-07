using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.JobPosition.GetJobPositions; 

public record GetJobPositionsQuery(string? Name) : IQuery<JobPositionsResponse>;