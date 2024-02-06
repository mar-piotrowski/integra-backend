using Application.Abstractions.Messaging;

namespace Application.Features.Document.Delete;

public record DeleteDocumentCommand(int DocumentId) : ICommand;