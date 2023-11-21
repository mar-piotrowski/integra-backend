using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Commands;

public record CreateAbsenceCommand(
    DateTime StartDate, 
    DateTime EndDate,
    string? DiseaseCode,
    string Series,
    string Number,
    DateTime ReleaseDate,
    DateTime DeliveryDate,
    string Description,
    int UserId
) : ICommand ;