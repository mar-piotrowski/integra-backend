using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Reject; 

public record RejectAbsenceCommand(AbsenceId AbsenceId) : ICommand;