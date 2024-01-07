using Application.Abstractions.Messaging;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.SchoolHistory.UpdateSchoolHistory;

public record UpdateSchoolHistoryCommand(
    SchoolHistoryId SchoolHistoryId,
    string SchoolName,
    SchoolDegree Degree,
    string Specialization,
    string Title,
    DateTime StartDate,
    DateTime EndDate
) : ICommand;