using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.SchoolHistory.GetSchoolHistories;

public record GetUserSchoolHistoriesQuery(UserId UserId) : IQuery<List<SchoolHistoryDto>>;