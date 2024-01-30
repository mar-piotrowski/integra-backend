using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence.Delete;

public record DeleteAbsenceCommand(AbsenceId AbsenceId) : ICommand;