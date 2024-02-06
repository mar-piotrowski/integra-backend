using Application.Features.Document.Create.Documents.Invoice;
using Application.Features.Document.Create.Documents.Mm;
using Application.Features.Document.Create.Documents.Pw;
using Application.Features.Document.Create.Documents.Pz;
using Application.Features.Document.Create.Documents.Rw;
using Application.Features.Document.Create.Documents.Wz;
using Domain.Enums;

namespace Application.Features.Document.Create.Documents;

public class DocumentFactory : IDocumentFactory {
    private readonly DocumentInvoice _documentInvoice;
    private readonly DocumentMm _documentMm;
    private readonly DocumentPw _documentPw;
    private readonly DocumentPz _documentPz;
    private readonly DocumentRw _documentRw;
    private readonly DocumentWz _documentWz;

    public DocumentFactory(
        DocumentInvoice documentInvoice,
        DocumentMm documentMm,
        DocumentPw documentPw,
        DocumentPz documentPz,
        DocumentRw documentRw,
        DocumentWz documentWz
    ) {
        _documentInvoice = documentInvoice;
        _documentMm = documentMm;
        _documentPw = documentPw;
        _documentPz = documentPz;
        _documentRw = documentRw;
        _documentWz = documentWz;
    }

    public IDocument ChooseDocument(DocumentType documentType) => documentType switch {
        DocumentType.Invoice => _documentInvoice,
        DocumentType.Mm => _documentMm,
        DocumentType.Wz => _documentWz,
        DocumentType.Pz => _documentPz,
        DocumentType.Rw => _documentRw,
        DocumentType.Pw => _documentPw 
    };
}