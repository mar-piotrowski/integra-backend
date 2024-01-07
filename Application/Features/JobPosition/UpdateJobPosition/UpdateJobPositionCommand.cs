using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.JobPosition.UpdateJobPosition; 

public record UpdateJobPositionCommand(JobPositionId JobPositionId, string Title) : ICommand;