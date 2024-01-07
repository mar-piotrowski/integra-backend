using Application.Abstractions.Messaging;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.SchoolHistory.CreateSchoolHistory;

public record CreateUserSchoolHistoryCommand(
    UserId UserId,
    string SchoolName,
    SchoolDegree Degree,
    string Specialization,
    string Title,
    DateTime StartDate,
    DateTime EndDate
) : ICommand;