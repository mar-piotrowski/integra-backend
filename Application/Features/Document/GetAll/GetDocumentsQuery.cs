using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.Enums;

namespace Application.Features.Document.GetAll;

public record GetDocumentsQuery(List<DocumentType> DocumentTypes) : IQuery<DocumentsResponse>;