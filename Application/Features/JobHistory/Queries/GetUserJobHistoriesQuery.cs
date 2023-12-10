using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobHistory.Queries; 

public record GetUserJobHistoriesQuery(UserId UserId) : IQuery<List<JobHistoryDto>>;