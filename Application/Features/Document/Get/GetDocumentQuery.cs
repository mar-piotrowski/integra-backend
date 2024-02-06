using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Document.Get;

public record GetDocumentQuery(int DocumentId) : IQuery<DocumentDto>;