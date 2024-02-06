using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IDocumentRepository : IRepository<Document, DocumentId> {
    public Document? FindByNumber(string number);
}