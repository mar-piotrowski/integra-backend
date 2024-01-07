using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobHistory.UpdateJobHistory;

public record UpdateJobHistoryCommand(
    JobHistoryId JobHistoryId,
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime EndDate
) : ICommand;