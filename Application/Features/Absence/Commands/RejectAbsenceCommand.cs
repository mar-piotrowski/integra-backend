using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Commands; 

public record RejectAbsenceCommand(AbsenceId AbsenceId, string Description) : ICommand;