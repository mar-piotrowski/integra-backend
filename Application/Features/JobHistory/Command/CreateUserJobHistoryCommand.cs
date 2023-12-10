using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobHistory.Command;

public record CreateUserJobHistoryCommand(
    UserId UserId,
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime EndDate
) : ICommand;