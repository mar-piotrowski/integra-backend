using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobHistory.DeleteJobHistory; 

public record DeleteJobHistoryCommand(JobHistoryId JobHistoryId) : ICommand;