using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Absence.Create;

public record CreateAbsenceCommand(
    AbsenceType Type,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,
    string? DiseaseCode,
    string? Series,
    string? Number,
    string? Description,
    int UserId,
    bool Accepted
) : ICommand;