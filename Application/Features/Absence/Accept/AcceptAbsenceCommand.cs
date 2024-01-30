using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Accept;

public record AcceptAbsenceCommand(AbsenceId AbsenceId) : ICommand;