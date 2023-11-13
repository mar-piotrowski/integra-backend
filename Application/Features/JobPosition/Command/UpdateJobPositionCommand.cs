using Application.Abstractions.Messaging;

namespace Application.Features.JobPosition.Command; 

public record UpdateJobPositionCommand(int JobPositionId, string Title) : ICommand;