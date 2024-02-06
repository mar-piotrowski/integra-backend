using Domain.Enums;

namespace Application.Features.Document.Create.Documents;

public interface IDocumentFactory {
    public IDocument ChooseDocument(DocumentType documentType);
}