using Application.Abstractions.Messaging;

namespace Application.Features.Absence.CreateAbsence;

public record CreateAbsenceCommand(
    DateTime StartDate,
    DateTime EndDate,
    string? DiseaseCode,
    string? Series,
    string? Number,
    DateTime ReleaseDate,
    DateTime DeliveryDate,
    string? Description,
    int UserId
) : ICommand;