using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IDocumentRepository : IRepository<Document, DocumentId> {
    public IEnumerable<Document> FindAll(List<DocumentType> documentTypes);
    public Document? FindByNumber(string number);
}