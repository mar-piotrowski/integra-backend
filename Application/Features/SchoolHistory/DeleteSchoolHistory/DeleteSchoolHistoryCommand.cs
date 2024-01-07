using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.SchoolHistory.DeleteSchoolHistory; 

public record DeleteSchoolHistoryCommand(SchoolHistoryId SchoolHistoryId) : ICommand;