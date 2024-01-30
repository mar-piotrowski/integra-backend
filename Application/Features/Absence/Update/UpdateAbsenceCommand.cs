using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Update;

public record UpdateAbsenceCommand (
    AbsenceId AbsenceId,
    DateTime StartDate,
    DateTime EndDate,
    string? DiseaseCode,
    string? Series,
    string? Number,
    string? Description,
    UserId UserId
): ICommand;