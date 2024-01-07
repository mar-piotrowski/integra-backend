using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.AcceptAbsence;

public record AcceptAbsenceCommand(AbsenceId AbsenceId, string Description) : ICommand;