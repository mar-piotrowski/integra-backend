using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Features.WorkingTime.EndWork;

public record EndWorkCommand(CardNumber CardNumber) : ICommand;