using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobHistory.Command; 

public record DeleteJobHistoryCommand(JobHistoryId JobHistoryId) : ICommand;