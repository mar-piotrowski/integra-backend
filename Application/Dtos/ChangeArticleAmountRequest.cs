using Application.Abstractions.Messaging;

namespace Application.Dtos;

public record ChangeArticleAmountRequest(decimal Amount) : ICommand;