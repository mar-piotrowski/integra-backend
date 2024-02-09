using Domain.Enums;

namespace Application.Features.Document.Documents;

public interface IDocumentFactory {
    public IDocument ChooseDocument(DocumentType documentType);
}