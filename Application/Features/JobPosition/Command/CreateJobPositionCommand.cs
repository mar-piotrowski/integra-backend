using Application.Abstractions.Messaging;

namespace Application.Features.JobPosition.Command;

public record CreateJobPositionCommand(string Title) : ICommand;