using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Commands;

public record AcceptAbsenceCommand(AbsenceId AbsenceId, string Description) : ICommand;