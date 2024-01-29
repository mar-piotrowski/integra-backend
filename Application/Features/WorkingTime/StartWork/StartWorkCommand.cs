using Application.Abstractions.Messaging;
using Domain.ValueObjects;

namespace Application.Features.WorkingTime.StartWork;

public record StartWorkCommand(CardNumber CardNumber) : ICommand;