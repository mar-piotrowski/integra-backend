using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.SchoolHistory.Commands; 

public record DeleteSchoolHistoryCommand(SchoolHistoryId SchoolHistoryId) : ICommand;