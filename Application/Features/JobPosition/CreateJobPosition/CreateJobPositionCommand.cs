using Application.Abstractions.Messaging;

namespace Application.Features.JobPosition.CreateJobPosition;

public record CreateJobPositionCommand(string Title) : ICommand;