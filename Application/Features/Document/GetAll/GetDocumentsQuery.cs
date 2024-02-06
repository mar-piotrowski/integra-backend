using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Document.GetAll;

public record GetDocumentsQuery : IQuery<DocumentsResponse>;